// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK.File;
using Hedera.Hashgraph.TCK.Tests.FileService.Responses;

using System;
using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.FileService
{
    /// <summary>
    /// FileService for file related methods
    /// </summary>
    public partial class FileService : Service
    {
        private static readonly TimeSpan DEFAULT_GRPC_DEADLINE = TimeSpan.FromSeconds(3);

        private readonly SdkService sdkService;
        public FileService(SdkService sdkService)
        {
            this.sdkService = sdkService;
        }

        /// <summary>
        ///  Map FileInfo from SDK to FileInfoResponse for JSON-RPC
        /// </summary>
        private FileInfoResponse MapFileInfoResponse(FileInfo fileInfo)
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