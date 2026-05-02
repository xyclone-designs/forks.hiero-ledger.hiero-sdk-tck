// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Util;

using Hedera.Hashgraph.SDK.Fee;

using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.TokenService.Params
{
    public class TokenUpdateFeeScheduleParams : Parameters
    {
        public TokenUpdateFeeScheduleParams(Dictionary<string, object> parameters) : base(parameters)
        {
            TokenId = parameters["tokenId"] as string;
            CommonTransactionParams = new CommonTransactionParams(parameters);
            CustomFees = JSONRPCParamParser.ParseCustomFees(parameters);
        }

        public string? TokenId { get; private set; }
        public IList<CustomFee>? CustomFees { get; private set; }
        public CommonTransactionParams? CommonTransactionParams { get; private set; }
    }
}