// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Contract;
using Hedera.Hashgraph.TCK.Tests.ContractService.Params;
using Hedera.Hashgraph.TCK.Tests.ContractService.Responses;

namespace Hedera.Hashgraph.TCK.Tests.ContractService
{
    public partial class ContractService 
    {
        public virtual ContractResponse.ContractInfoQueryResponse ContractInfoQuery(InfoQueryContractParams @params)
        {
            var query = new ContractInfoQuery();
            var client = sdkService.GetClient(@params.SessionId);
            
            if (!string.IsNullOrEmpty(@params.ContractId))
                query.ContractId = ContractId.FromString(@params.ContractId);
            
            if (!string.IsNullOrEmpty(@params.QueryPayment))
                query.QueryPayment = Hbar.FromTinybars(long.Parse(@params.QueryPayment));
            
            if (!string.IsNullOrEmpty(@params.MaxQueryPayment))
                query.MaxQueryPayment = Hbar.FromTinybars(long.Parse(@params.MaxQueryPayment));
            
            var result = query.Execute(client);

            return MapContractInfo(result);
        }
    }
}