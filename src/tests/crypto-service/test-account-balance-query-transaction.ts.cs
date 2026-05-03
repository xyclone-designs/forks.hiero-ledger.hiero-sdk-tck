// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.CryptoService.Params;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public partial class TestAccount 
    {
        public virtual AccountBalanceResponse AccountBalanceQuery(AccountBalanceQueryParams @params)
        {
            var query = QueryBuilders.AccountBuilder.BuildAccountBalanceQuery(@params);
            var client = sdkService.GetClient(@params.SessionId);
            var result = query.Execute(client);

            return new AccountBalanceResponse(result.Hbars.ToString().Replace(" tℏ", ""), result.Tokens, result.TokenDecimals);
        }
    }
}