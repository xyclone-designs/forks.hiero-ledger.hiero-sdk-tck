// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Schedule;
using Hedera.Hashgraph.TCK.Tests.ScheduleService.Params;
using Hedera.Hashgraph.TCK.Tests.ScheduleService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.ScheduleService
{
    public partial class TestSchedule
    {
        public virtual ScheduleInfoResponse GetScheduleInfo(ScheduleInfoParams @params)
        {
            ScheduleInfoQuery query = QueryBuilders.ScheduleBuilder.BuildScheduleInfoQuery(@params);
            
            Client client = sdkService.GetClient(@params.SessionId);

            if (@params.GetCost is not null)
            {
                Hbar cost = query.GetCost(client);

                return new ScheduleInfoResponse { Cost = cost.ToTinybars().ToString() };
            }

            ScheduleInfo result = query.Execute(client);

            return MapScheduleInfoResponse(result);
        }
    }
}