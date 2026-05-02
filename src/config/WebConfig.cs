// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Controllers;

namespace Hedera.Hashgraph.TCK.Config
{
    public class WebConfig : WebMvcConfigurer
    {
        public virtual void AddInterceptors(InterceptorRegistry registry)
        {
            registry.AddInterceptor(new JRPCInterceptor());
        }
    }
}