// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Token;
using Hedera.Hashgraph.SDK.Transactions;
using Hedera.Hashgraph.TCK.Util;
using Hedera.Hashgraph.TCK.Tests.TokenService.Params;
using Hedera.Hashgraph.TCK.Tests.TokenService.Responses;

namespace Hedera.Hashgraph.TCK.Tests.TokenService
{
    public partial class TokenService 
    {
        public virtual TokenResponse UpdateToken(TokenUpdateParams @params)
        {
            TokenUpdateTransaction tokenUpdateTransaction = TransactionBuilders.TokenBuilder.BuildUpdate(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            @params.CommonTransactionParams?.FillOutTransaction(tokenUpdateTransaction, client);
            TransactionReceipt transactionReceipt = tokenUpdateTransaction.Execute(client).GetReceipt(client);
            
            return new TokenResponse("", transactionReceipt.Status);
        }
    }
}