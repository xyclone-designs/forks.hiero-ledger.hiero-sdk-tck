// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Util;

using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.FileService.Params
{
    public class FileCreateParams : Parameters
    {
        public FileCreateParams(Dictionary<string, object> parameters) : base(parameters)
        {
            Keys = parameters["keys"] as IList<string>;
            Contents = parameters["contents"] as string;
            ExpirationTime = parameters["expirationTime"] as string;
            Memo = parameters["memo"] as string;
            CommonTransactionParams = new CommonTransactionParams(parameters);
        }

        public IList<string>? Keys { get; private set; }
        public string? Contents { get; private set; }
        public string? ExpirationTime { get; private set; }
        public string? Memo { get; private set; }
        public CommonTransactionParams? CommonTransactionParams { get; private set; }
    }
}