// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK.Cryptocurrency;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Params;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public partial class AccountService 
    {
        public virtual GetAccountInfoResponse GetAccountInfo(GetAccountInfoParams @params)
        {
            var client = sdkService.GetClient(@params.SessionId);
            var query = new AccountInfoQuery();
            
            if (!string.IsNullOrEmpty(@params.AccountId))
                query.AccountId = AccountId.FromString(@params.AccountId);

            var accountInfo = query.Execute(client);

            return MapAccountInfoResponse(accountInfo);
        }
    }
}