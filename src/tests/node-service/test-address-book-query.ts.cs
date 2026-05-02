// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.SDK;
using Hedera.Hashgraph.SDK.File;
using Hedera.Hashgraph.SDK.Networking;
using Hedera.Hashgraph.TCK.Tests.NodeService.Params;
using Hedera.Hashgraph.TCK.Tests.NodeService.Responses;

using Org.BouncyCastle.Utilities.Encoders;

using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.NodeService
{
    public partial class NodeService 
    {
        public virtual AddressBookResponse AddressBookQuery(AddressBookQueryParams @params)
        {
            AddressBookQuery query = new ()
            {
                FileId = FileId.FromString(@params.FileId) 
            };

            Client client = sdkService.GetClient(@params.SessionId);
            NodeAddressBook addressBook = query.Execute(client);
            AddressBookResponse response = new ();

            foreach (NodeAddress address in addressBook.NodeAddresses)
                response.NodeAddresses.Add(new AddressBookResponse.NodeAddress
                {
                    PublicKey = address.PublicKey ?? "",
                    AccountId = address.AccountId?.ToString() ?? "",
                    NodeId = address.NodeId,
                    CertHash = address.CertHash?.ToString() ?? "",
                    ServiceEndpoints =
                    [
                        .. address.Addresses .Select((sdkEndpoint) => new AddressBookResponse.Endpoint
                        {
                            Address = sdkEndpoint.Address is not null ? Hex.ToHexString(sdkEndpoint.Address) : null,
                            Port = sdkEndpoint.Port,
                            DomainName = sdkEndpoint.DomainName ?? "",
                        })
                    ],
                    Description = address.Description,
                    Stake = address.Stake
                });

            return response;
        }
    }
}