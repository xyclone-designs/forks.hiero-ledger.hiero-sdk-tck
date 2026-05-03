// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.CryptoService.Params;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public partial class TestAccount 
    {
        public virtual AccountAllowanceResponse ApproveAllowance(AccountAllowanceParams @params)
        {
            var tx = TransactionBuilders.AccountBuilder.BuildApproveAllowance(@params);
            var client = sdkService.GetClient(@params.SessionId);
            
            @params.CommonTransactionParams?.FillOutTransaction(tx, client);
            
            var transactionReceipt = tx.Execute(client).GetReceipt(client);
            return new AccountAllowanceResponse(transactionReceipt.Status);
        }
    }
}