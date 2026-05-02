// SPDX-License-Identifier: Apache-2.0
using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService.Params
{
    public class GetAccountInfoParams : Parameters
    {
        public GetAccountInfoParams(Dictionary<string, object> parameters) : base(parameters)
        {
            AccountId = parameters["accountId"] as string;
        }

        public string? AccountId { get; private set; }
    }
}