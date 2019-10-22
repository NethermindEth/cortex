﻿using System.Collections.Generic;
using Cortex.Containers;
using Cortex.SimpleSerialize;

namespace Cortex.BeaconNode.Ssz
{
    public static class AttestationDataExtensions
    {
        public static SszContainer ToSszContainer(this AttestationData item)
        {
            return new SszContainer(GetValues(item));
        }

        private static IEnumerable<SszElement> GetValues(AttestationData item)
        {
            // LMD GHOST vote
            yield return item.BeaconBlockRoot.ToSszBasicVector();
            // FFG vote
            yield return item.Source.ToSszContainer();
            yield return item.Target.ToSszContainer();
            // Crosslink vote
            yield return item.Crosslink.ToSszContainer();
        }
    }
}