// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService.Responses
{
    public class TransferResponse(ResponseStatus? status)
    {
        public ResponseStatus? Status { get; init; } = status;
    }
}
