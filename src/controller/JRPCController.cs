// SPDX-License-Identifier: Apache-2.0
using Com.Hedera.Hashgraph.Tck.Annotation;
using Hedera.Hashgraph.TCK.Util;
using Com.Thetransactioncompany.Jsonrpc2;
using Com.Thetransactioncompany.Jsonrpc2.Server;
using Jakarta.Servlet.Http;
using Org.Slf4j;
using Org.Springframework.Context;
using Org.Springframework.Web.Bind.Annotation;
using StreamJsonRpc.Protocol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Hedera.Hashgraph.TCK.Controllers
{
    public class JRPCController
    {
        private readonly Logger logger = LoggerFactory.GetLogger(typeof(JRPCController));
        private readonly Dispatcher dispatcher;
        public JRPCController(Dispatcher dispatcher, ApplicationContext applicationContext)
        {
            this.dispatcher = dispatcher;
            JSONRPC2ServiceScanner.RegisterServices(dispatcher, applicationContext);
        }

        /// <summary>
        /// Endpoint to handle all incoming JSON-RPC requests
        /// </summary>
        public virtual string HandleJSONRPC2Request(HttpServletRequest request)
        {
            JsonRpcRequest req = request.GetAttribute("jsonrpcRequest");
            var resp = dispatcher.Process(req, null);
            if (resp.GetError() != null)
            {
                string errorMessage = String.Format("Error occurred processing JSON-RPC request: %s, Response error: %s", req.ToJSONString(), resp.GetError().ToString());
                logger.Info(errorMessage);
            }

            return resp.ToJSONString();
        }
    }
}