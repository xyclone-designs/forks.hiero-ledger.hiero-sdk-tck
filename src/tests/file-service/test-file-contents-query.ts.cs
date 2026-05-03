// SPDX-License-Identifier: Apache-2.0
using Google.Protobuf;

using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.File;
using Hedera.Hashgraph.TCK.Tests.FileService.Params;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;
using Hedera.Hashgraph.TCK.Util;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    public partial class TestFile 
    {
        public virtual FileContentsResponse GetFileContents(FileContentsParams @params)
        {
            FileContentsQuery query = QueryBuilders.FileBuilder.BuildFileContents(@params);
            Client client = sdkService.GetClient(@params.SessionId);
            ByteString response = query.Execute(client);

            // Convert ByteString to string
            string contents = response.ToStringUtf8();

            return new FileContentsResponse(contents);
        }
    }
}