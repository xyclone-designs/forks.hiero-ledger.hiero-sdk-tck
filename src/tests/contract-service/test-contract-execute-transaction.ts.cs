// SPDX-License-Identifier: Apache-2.0
using Google.Protobuf;

using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Contract;
using Hedera.Hashgraph.TCK.Tests.ContractService.Params;
using Hedera.Hashgraph.TCK.Tests.ContractService.Responses;

using Org.BouncyCastle.Utilities.Encoders;

namespace Hedera.Hashgraph.TCK.Tests.ContractService
{
    public partial class ContractService 
    {
        public virtual ContractResponse ExecuteContract(ExecuteContractParams @params)
        {
            var transaction = new ContractExecuteTransaction();
            var client = sdkService.GetClient(@params.SessionId);
            
            if (!string.IsNullOrEmpty(@params.ContractId))
                transaction.ContractId = ContractId.FromString(@params.ContractId);
            
            if (!string.IsNullOrEmpty(@params.Gas))
                transaction.Gas = long.Parse(@params.Gas);
            
            if (!string.IsNullOrEmpty(@params.Amount))
                transaction.PayableAmount = Hbar.FromTinybars(long.Parse(@params.Amount));
            
            if (!string.IsNullOrEmpty(@params.FunctionParameters))
                transaction.FunctionParameters = ByteString.CopyFrom(Hex.Decode(@params.FunctionParameters));
            
            @params.CommonTransactionParams?.FillOutTransaction(transaction, client);
            
            var receipt = transaction.Execute(client).GetReceipt(client);

            return new ContractResponse("", receipt.Status);
        }
    }
}