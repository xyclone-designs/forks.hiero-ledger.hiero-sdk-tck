// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Util;

using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Consensus;
using Hedera.Hashgraph.TCK.Tests.TopicService.Params;
using Hedera.Hashgraph.TCK.Tests.TopicService.Responses;

namespace Hedera.Hashgraph.TCK.Tests.TopicService
{
    public partial class TopicService 
    {
        public virtual TopicInfoResponse GetTopicInfo(TopicInfoQueryParams @params)
        {
            TopicInfoQuery query = QueryBuilders.TopicBuilder.BuildTopicInfoQuery(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            TopicInfo result = query.Execute(client);

            return MapTopicInfoResponse(result);
        }
    }
}