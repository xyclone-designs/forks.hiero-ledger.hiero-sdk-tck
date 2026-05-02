// SPDX-License-Identifier: Apache-2.0
using Com.Thetransactioncompany.Jsonrpc2;
using Jakarta.Servlet.Http;
using Java.Io;
using Org.Springframework.Web.Servlet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Hedera.Hashgraph.TCK.Controllers
{
    public class JRPCInterceptor :  HandlerInterceptor
    {
        public virtual bool PreHandle(HttpServletRequest request, HttpServletResponse response, object handler)
        {

            // Map HTTP Servlet Request to JSON-RPC Request
            var jsonrpcRequest = MapToJSONRPC2Request(request);

            // Store the JSON-RPC request in request attribute for further processing
            request.SetAttribute("jsonrpcRequest", jsonrpcRequest);

            // Continue processing the request
            return true;
        }

        virtual JSONRPC2Request MapToJSONRPC2Request(HttpServletRequest httpRequest)
        {
            // Read the JSON-RPC request from the HTTP request body
            BufferedReader reader = httpRequest.GetReader();
            StringBuilder requestBody = new StringBuilder();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                requestBody.Append(line);
            }

            reader.Dispose();

            // Parse the JSON-RPC request
            return JSONRPC2Request.Parse(requestBody.ToString());
        }
    }
}