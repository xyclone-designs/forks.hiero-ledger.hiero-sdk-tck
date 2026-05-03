// SPDX-License-Identifier: Apache-2.0
using System;
using System.Collections.Generic;
using System.Linq;

using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.Cryptocurrency;
using Hedera.Hashgraph.SDK.Token;
using Hedera.Hashgraph.SDK.Nfts;
using Hedera.Hashgraph.SDK.LiveHashes;
using Hedera.Hashgraph.TCK.Tests.CryptoService.Responses;

namespace Hedera.Hashgraph.TCK.Tests.CryptoService
{
    public class CryptoService : Service
    {
        private readonly SdkService sdkService;

        public CryptoService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }
    }
}