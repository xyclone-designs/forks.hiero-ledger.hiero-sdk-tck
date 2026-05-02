// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.FileService.Params;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    public partial class FileService 
    {
        public virtual FileResponse CreateFile(FileCreateParams @params)
        {
            var transaction = TransactionBuilders.FileBuilder.BuildCreate(@params);
            var client = sdkService.GetClient(@params.SessionId);
            
            @params.CommonTransactionParams?.FillOutTransaction(transaction, client);
            
            var txResponse = transaction.Execute(client);
            var receipt = txResponse.GetReceipt(client);
            string fileId = "";
            if (receipt.Status == SDK.ResponseStatus.Success && receipt.FileId != null)
            {
                fileId = receipt.FileId.ToString();
            }

            return new FileResponse(fileId, receipt.Status);
        }
    }
}