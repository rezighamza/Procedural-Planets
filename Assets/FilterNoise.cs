using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterNoise : INoiseFilter 
{
    Noise noise = new Noise();
    NoiseSett noiseSett;
    public FilterNoise(NoiseSett noiseSett)
    {
        this.noiseSett = noiseSett;
    }

    public float Evaluate(Vector3 point)
    {
        float noiseValue = 0;
        float frequency = noiseSett.baseRoughness;
        float amplitude = 1;
        for (int i = 0; i < noiseSett.numLayers; i++)
        {
            float v = noise.Evaluate(point * frequency + noiseSett.center);
            noiseValue += (v + 1) * .5f * amplitude;
            frequency *= noiseSett.roughness;
            amplitude *= noiseSett.persistance;
        }
        noiseValue = Mathf.Max(0, noiseValue - noiseSett.minValue);
        return noiseValue * noiseSett.strength;
    }
}
