// SPDX-License-Identifier: Apache-2.0
using Hedera.Hashgraph.TCK.Util;
using Hedera.Hashgraph.SDK.Fee;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hedera.Hashgraph.TCK.Tests.TopicService.Params
{
    /// <summary>
    /// CustomFeeLimit for topic message submit method
    /// </summary>
    public class CustomFeeLimit : Parameters
    {
        public CustomFeeLimit(Dictionary<string, object> parameters) : base(parameters)
        {
            PayerId = parameters["payerId"] as string;
            var fixedFeesList = (IList<Dictionary<string, object>>)parameters["fixedFees"];

            if (fixedFeesList != null)
            {
                FixedFees = fixedFeesList.Select(fixedFeeMap =>
                {
                    try
                    {
                        return new CustomFee.FixedFee(fixedFeeMap);
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Failed to parse fixed fee", e);
                    }
                }).ToList();
            }
        }

        public string? PayerId { get; private set; }
        public List<CustomFee.FixedFee>? FixedFees { get; private set; }
    }
}