// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Contract;
using Hedera.Hashgraph.TCK.Tests.ContractService.Responses;

using System;

namespace Hedera.Hashgraph.TCK.Tests.ContractService
{
    public class ContractService : Service
    {
        private static readonly TimeSpan DEFAULT_GRPC_DEADLINE = TimeSpan.FromSeconds(10);
        private readonly SdkService sdkService;

        public ContractService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }
    }
}