// SPDX-License-Identifier: Apache-2.0

namespace Hedera.Hashgraph.TCK.Tests.Ethereum
{
    public partial class EthereumService : Service
    {
        private readonly SdkService sdkService;
        public EthereumService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }
    }
}