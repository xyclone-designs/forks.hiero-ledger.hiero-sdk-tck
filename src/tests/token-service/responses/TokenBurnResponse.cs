// SPDX-License-Identifier: Apache-2.0

using Hedera.Hashgraph.SDK;

namespace Hedera.Hashgraph.TCK.Tests.TokenService.Responses
{
    public class TokenBurnResponse : TokenResponse
    {
        public TokenBurnResponse(string? tokenId, ResponseStatus status, string? newTotalSupply) : base(tokenId, status)
        {
            NewTotalSupply = newTotalSupply;
        }

        public string? NewTotalSupply { get; set; }
    }
}