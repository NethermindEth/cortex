﻿using System.Collections.Generic;
using System.Linq;
using Cortex.Containers;
using Cortex.SimpleSerialize;

namespace Cortex.BeaconNode.Ssz
{
    public static class DepositExtensions
    {
        public static SszContainer ToSszContainer(this Deposit item)
        {
            return new SszContainer(GetValues(item));
        }

        public static SszList ToSszList(this IEnumerable<Deposit> list, ulong limit)
        {
            return new SszList(list.Select(x => x.ToSszContainer()), limit);
        }

        private static IEnumerable<SszElement> GetValues(Deposit item)
        {
            // TODO: fill in
            yield return new SszBasicElement((byte)0);
        }
    }
}