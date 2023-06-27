using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NoiseFilterFactory 
{
    public static INoiseFilter CreateNoiseFilter(NoiseSett sett)
    {
        switch (sett.filterType)
        {
            case NoiseSett.FilterType.Ridgid:
                return new RidgidNoiseFilter(sett);
            case NoiseSett.FilterType.Filter:
                return new FilterNoise(sett);
        }
        return null;
    }

}
