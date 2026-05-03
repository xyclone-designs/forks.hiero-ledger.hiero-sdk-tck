// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;

namespace Hedera.Hashgraph.TCK.Tests.TokenService
{
    public partial class TokenService : Service
    {
        private readonly SdkService sdkService;
        public TokenService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }
    }
}