using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidgidNoiseFilter : INoiseFilter
{
    Noise noise = new Noise();
    NoiseSett noiseSett;
    public RidgidNoiseFilter(NoiseSett noiseSett)
    {
        this.noiseSett = noiseSett;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = noiseSett.baseRoughness;
        float amplitude = 1;
        float weight = 1;
        for (int i = 0; i < noiseSett.numLayers; i++)
        {
            float v = 1 - Mathf.Abs(noise.Evaluate(point * frequency + noiseSett.center));
            v *= v;
            v *= weight;
            weight = Mathf.Clamp01(v * noiseSett.weightMultiplier);
            v *= amplitude;
            amplitude *= noiseSett.persistance;
            frequency *= noiseSett.roughness;
            noiseValue += v;
        }
        noiseValue = Mathf.Max(0, noiseValue - noiseSett.minValue);
        return noiseValue * noiseSett.strength;
    }
}
