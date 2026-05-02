// SPDX-License-Identifier: Apache-2.0
using System;

namespace Hedera.Hashgraph.TCK.Tests.NodeService
{
    public partial class NodeService : Service
    {
        private static readonly TimeSpan DEFAULT_GRPC_DEADLINE = TimeSpan.FromSeconds(10);

        private readonly SdkService sdkService;
        public NodeService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }
    }
}