// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.ContractService.Params;
using Hedera.Hashgraph.TCK.Tests.ContractService.Responses;
using Hedera.Hashgraph.TCK.Util;

using Org.BouncyCastle.Utilities.Encoders;

namespace Hedera.Hashgraph.TCK.Tests.ContractService
{
    public partial class TestContract 
    {
        public virtual ContractByteCodeResponse ContractByteCodeQuery(ContractByteCodeQueryParams @params)
        {
            var query = QueryBuilders.BuildContractBytecode(@params);
            var client = sdkService.GetClient(@params.SessionId);
            var response = query.Execute(client);

            return new ContractByteCodeResponse(query.ContractId?.ToString(), Hex.ToHexString(response.ToByteArray()));
        }
    }
}