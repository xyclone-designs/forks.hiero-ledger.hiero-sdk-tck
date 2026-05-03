// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK.File;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;

using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    public partial class TestFile(SdkService sdkService) : FileService(sdkService)
    {
        private static FileInfoResponse MapFileInfoResponse(FileInfo fileInfo)
        {
            return new FileInfoResponse(
                fileInfo.FileId.ToString(), 
                fileInfo.Size.ToString(), 
                fileInfo.ExpirationTime.ToString(),
                fileInfo.IsDeleted, 
                fileInfo.FileMemo, 
                fileInfo.LedgerId.ToString(),
                [.. fileInfo.Keys.Select(_ => _.ToString() ?? string.Empty)]);
        }
    }
}