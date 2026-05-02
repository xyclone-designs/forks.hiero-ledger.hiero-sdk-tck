// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.FileService.Params;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    public partial class FileService 
    {
        public virtual FileResponse DeleteFile(FileDeleteParams @params)
        {
            var transaction = TransactionBuilders.FileBuilder.BuildDelete(@params);
            var client = sdkService.GetClient(@params.SessionId);
            
            @params.CommonTransactionParams?.FillOutTransaction(transaction, client);
            
            var txResponse = transaction.Execute(client);
            var receipt = txResponse.GetReceipt(client);

            return new FileResponse("", receipt.Status);
        }
    }
}