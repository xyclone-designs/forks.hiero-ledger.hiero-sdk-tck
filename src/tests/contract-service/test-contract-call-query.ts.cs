// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Tests.ContractService.Params;
using Hedera.Hashgraph.TCK.Tests.ContractService.Responses;
using Hedera.Hashgraph.TCK.Util;

using Org.BouncyCastle.Utilities.Encoders;

using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.ContractService
{
    public partial class ContractService 
    {
        public virtual ContractCallResponse ContractCallQuery(ContractCallQueryParams @params)
        {
            var query = QueryBuilders.BuildContractCall(@params);
            var client = sdkService.GetClient(@params.SessionId);
            var result = query.Execute(client);

            return new ContractCallResponse(
                result.ContractId?.ToString() ?? "",
                result.EvmAddress,
                result.ErrorMessage,
                result.GasUsed,
                result.Logs?.ToList(),
                result.Gas,
                result.HbarAmount,
                result.SenderAccountId,
                result.SignerNonce,
                Hex.ToHexString(result.AsBytes()));
        }
    }
}