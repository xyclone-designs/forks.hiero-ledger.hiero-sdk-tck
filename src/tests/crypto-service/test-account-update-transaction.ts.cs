// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.CryptoService.Params;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public partial class TestAccount 
    {
        public virtual AccountResponse UpdateAccount(AccountUpdateParams @params)
        {
            var accountUpdateTransaction = TransactionBuilders.AccountBuilder.BuildUpdate(@params);
            var client = sdkService.GetClient(@params.SessionId);
            
            @params.CommonTransactionParams?.FillOutTransaction(accountUpdateTransaction, client);
            
            var transactionReceipt = accountUpdateTransaction.Execute(client).GetReceipt(client);

            return new AccountResponse(null, transactionReceipt.Status);
        }
    }
}