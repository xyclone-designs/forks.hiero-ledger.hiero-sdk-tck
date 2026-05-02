// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;

using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.TokenService.Responses
{
    public class TokenMintResponse : TokenResponse
    {
        public TokenMintResponse(string? tokenId, ResponseStatus status, string newTotalSupply, List<string> serialNumbers) : base(tokenId, status)
        {
            NewTotalSupply = newTotalSupply;
            SerialNumbers = serialNumbers;
        }

        public string NewTotalSupply { get; init; }
        public IList<string> SerialNumbers { get; init; }
    }
}