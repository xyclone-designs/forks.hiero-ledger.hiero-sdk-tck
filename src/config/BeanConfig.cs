// SPDX-License-Identifier: Apache-2.0

namespace Hedera.Hashgraph.TCK.Config
{
    public class BeanConfig
    {
        public virtual Dispatcher Dispatcher()
        {
            return new Dispatcher();
        }
    }
}