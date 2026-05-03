// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.File;
using Hedera.Hashgraph.TCK.Tests.FileService.Params;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    public partial class TestFile 
    {
        public virtual FileInfoResponse GetFileInfo(FileInfoQueryParams @params)
        {
            FileInfoQuery query = QueryBuilders.FileBuilder.BuildFileInfoQuery(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            FileInfo result = query.Execute(client);

            return MapFileInfoResponse(result);
        }
    }
}