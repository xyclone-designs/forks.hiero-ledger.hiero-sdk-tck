// SPDX-License-Identifier: Apache-2.0
using System;

namespace Hedera.Hashgraph.TCK.Exceptions
{
    public class InvalidJSONRPC2RequestException(string message) : Exception(message) { }
}