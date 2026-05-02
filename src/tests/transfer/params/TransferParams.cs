// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;

namespace Hedera.Hashgraph.TCK.Tests.Transfer.Params
{
    public class TransferParams
    {
        public TransferParams(Dictionary<string, object> jrpcParams)
        {
            HbarTransferParams? parsedHbar = jrpcParams["hbar"] is Dictionary<string, object> hbar ? new HbarTransferParams(hbar) : null;
            TokenTransferParams? parsedToken = jrpcParams["token"] is Dictionary<string, object> token ? new TokenTransferParams(token) : null;
            NftTransferParams? parsedNft = jrpcParams["nft"] is Dictionary<string, object> nfts ? new NftTransferParams(nfts) : null;

            // Only one allowance type should be allowed
            bool hasOnlyHbar = parsedHbar is not null && parsedToken is null && parsedNft is null;
            bool hasOnlyToken = parsedHbar is null && parsedToken is not null && parsedNft is null;
            bool hasOnlyNft = parsedHbar is null && parsedToken is null && parsedNft is not null;
            
            if (!hasOnlyHbar && !hasOnlyToken && !hasOnlyNft)
                throw new ArgumentException("invalid parameters: only one type of transfer SHALL be provided.");
        }

        public HbarTransferParams? Hbar { get; init; }
        public TokenTransferParams? Token { get; init; }
        public NftTransferParams? Nft { get; init; }
        public bool? Approved { get; init; }
    }
}