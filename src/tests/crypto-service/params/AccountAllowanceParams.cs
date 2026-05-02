// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Util;

using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService.Params
{
    public class AccountAllowanceParams : Parameters
    {
        public AccountAllowanceParams(Dictionary<string, object> parameters) : base(parameters)
        {
            Allowances = JSONRPCParamParser.ParseAllowances(parameters);
            CommonTransactionParams = new CommonTransactionParams(parameters);
        }

        public IList<AllowanceParams>? Allowances { get; private set; }
        public CommonTransactionParams? CommonTransactionParams { get; private set; }
    }
}