// SPDX-License-Identifier: Apache-2.0

namespace Hedera.Hashgraph.TCK.Tests.FileService.Responses
{
    public class FileContentsResponse(string? contents)
    {
        public string? Contents { get; init; } = contents;
    }
}