// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Nfts;
using Hedera.Hashgraph.TCK.Util;
using Hedera.Hashgraph.TCK.Tests.TokenService.Params;
using Hedera.Hashgraph.TCK.Tests.TokenService.Responses;

using System.Collections.Generic;

using Org.BouncyCastle.Utilities.Encoders;

namespace Hedera.Hashgraph.TCK.Tests.TokenService
{
    public partial class TokenService 
    {
        public virtual NftInfoResponse GetNftInfo(NftInfoQueryParams @params)
        {
            TokenNftInfoQuery query = QueryBuilders.TokenBuilder.BuildNftInfo(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            IList<TokenNftInfo> txResponse = query.Execute(client);
            TokenNftInfo tokenNftInfo = txResponse[0];

            return new NftInfoResponse
            {
                NftId = tokenNftInfo.NftId.ToString(),
                AccountId = tokenNftInfo.AccountId.ToString(),
                CreationTime = tokenNftInfo.CreationTime.ToUnixTimeSeconds().ToString(),
                Metadata = Hex.ToHexString(tokenNftInfo.Metadata),
                LedgerId = tokenNftInfo.LedgerId.ToString(),
                SpenderId = tokenNftInfo.SpenderId.ToString()
            };
        }
    }
}