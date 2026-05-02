// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Token;
using Hedera.Hashgraph.TCK.Util;
using Hedera.Hashgraph.TCK.Tests.TokenService.Params;
using Hedera.Hashgraph.TCK.Tests.TokenService.Responses;
using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.TokenService
{
    public partial class TokenService 
    {
        public virtual TokenInfoResponse GetTokenInfo(TokenInfoQueryParams @params)
        {
            TokenInfoQuery query = QueryBuilders.TokenBuilder.BuildTokenInfo(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            TokenInfo txResponse = query.Execute(client);

            return new TokenInfoResponse
            {
                TokenId = txResponse.TokenId.ToString(),
                Name = txResponse.Name,
                Symbol = txResponse.Symbol,
                Decimals = (int)txResponse.Decimals,
                TotalSupply = txResponse.TotalSupply.ToString(),
                TreasuryAccountId = txResponse.TreasuryAccountId.ToString(),
                AdminKey = txResponse.AdminKey?.ToString() ?? "",
                KycKey = txResponse.KycKey?.ToString() ?? "",
                FreezeKey = txResponse.FreezeKey?.ToString() ?? "",
                WipeKey = txResponse.WipeKey?.ToString() ?? "",
                SupplyKey = txResponse.SupplyKey?.ToString() ?? "",
                FeeScheduleKey = txResponse.FeeScheduleKey?.ToString() ?? "",
                DefaultFreezeStatus = txResponse.DefaultFreezeStatus,
                DefaultKycStatus = txResponse.DefaultKycStatus,
                IsDeleted = txResponse.IsDeleted,
                AutoRenewAccountId = txResponse.AutoRenewAccount != null ? txResponse.AutoRenewAccount.ToString() : "",
                AutoRenewPeriod = txResponse.AutoRenewPeriod.Seconds.ToString(),
                ExpirationTime = txResponse.ExpirationTime.ToUnixTimeSeconds().ToString(),
                TokenMemo = txResponse.TokenMemo,
                CustomFees = [], //CustomFee.FillOutCustomFees(txResponse.CustomFees),
                TokenType = txResponse.TokenType,
                SupplyType = txResponse.SupplyType,
                MaxSupply = txResponse.MaxSupply.ToString(),
                PauseKey = txResponse.PauseKey?.ToString() ?? "",
                PauseStatus = txResponse.PauseStatus,
                Metadata = txResponse.Metadata?.ToString() ?? "",
                MetadataKey = txResponse.MetadataKey?.ToString() ?? "",
                LedgerId = txResponse.LedgerId.ToString()
            };
        }
    }
}