// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;

namespace Hedera.Hashgraph.TCK.Tests.NodeService.Responses
{
    public class NodeResponse(string? nodeId, ResponseStatus? status)
    {
        public string? NodeId { get; set; } = nodeId;
        public ResponseStatus? Status { get; set; } = status;
    }
}