// SPDX-License-Identifier: Apache-2.0
namespace Hedera.Hashgraph.TCK.Tests
{
    public class SetupResponse
    {
        private string Message = "";
        private string Status = "";
        public SetupResponse(string message)
        {
            if (string.IsNullOrWhiteSpace(message) is false)
            {
                this.Message = message;
            }

            this.Status = "SUCCESS";
        }
    }
}