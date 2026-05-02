// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK.Consensus;
using Hedera.Hashgraph.SDK.Fee;
using Hedera.Hashgraph.TCK.Tests.TopicService.Responses;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.TopicService
{
    /// <summary>
    /// TopicService for topic related methods
    /// </summary>
    public partial class TopicService : Service
    {
        private static readonly TimeSpan DEFAULT_GRPC_DEADLINE = TimeSpan.FromSeconds(3);
        private readonly SdkService sdkService;
        
        public TopicService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }

        private TopicInfoResponse MapTopicInfoResponse(TopicInfo topicInfo)
        {
            return new TopicInfoResponse(
                topicInfo.TopicId.ToString(), 
                topicInfo.TopicMemo, 
                topicInfo.SequenceNumber.ToString(),
                topicInfo.RunningHash.ToString(), 
                topicInfo.AdminKey?.ToString(), 
                topicInfo.SubmitKey?.ToString(), 
                topicInfo.AutoRenewAccountId?.ToString(),
                topicInfo.AutoRenewPeriod.Seconds.ToString(), 
                topicInfo.ExpirationTime.ToUnixTimeSeconds().ToString(),
                topicInfo.FeeScheduleKey?.ToString(),
                [.. topicInfo.FeeExemptKeys.Select(key => key.ToString() ?? string.Empty)],
                topicInfo.CustomFees?.Select(MapToCustomFeeResponse).ToList(), 
                topicInfo.LedgerId.ToString());
        }
        private TopicInfoResponse.CustomFeeResponse MapToCustomFeeResponse(CustomFixedFee fee)
        {
            TopicInfoResponse.FixedFeeResponse fixedFee = new (fee.Amount.ToString(), fee.DenominatingTokenId?.ToString());

            return new TopicInfoResponse.CustomFeeResponse(fee.FeeCollectorAccountId?.ToString(), fee.AllCollectorsAreExempt, fixedFee);
        }
    }
}