// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.CryptoService.Params;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public partial class TestTransfer
    {
        public virtual TransferResponse TransferNftApproved(TransferCryptoParams @params)
        {
            var transaction = TransactionBuilders.TransferBuilder.BuildTransfer(@params);
            var client = sdkService.GetClient(@params.SessionId);

            @params.CommonTransactionParams?.FillOutTransaction(transaction, client);

            var transactionReceipt = transaction.Execute(client).GetReceipt(client);

            return new TransferResponse(transactionReceipt.Status);
        }
    }
}