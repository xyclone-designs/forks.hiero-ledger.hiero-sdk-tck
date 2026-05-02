// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;

namespace Hedera.Hashgraph.TCK.Tests.ScheduleService.Responses
{
    public class ScheduleResponse(string scheduleId, string transactionId, ResponseStatus status)
    {
        public string ScheduleId { get; set; } = scheduleId;
        public string TransactionId { get; set; } = transactionId;
        public ResponseStatus Status { get; set; } = status;
    }
}