// SPDX-License-Identifier: Apache-2.0
using System;

namespace Hedera.Hashgraph.TCK.Tests.NodeService
{
    public partial class TestNode(SdkService sdkService) : NodeService(sdkService) { }
}