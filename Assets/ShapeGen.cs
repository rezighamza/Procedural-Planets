using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeGen 
{
    ShapeSett shapeSettings;
    INoiseFilter[] filterNoise;
    
    
    public  ShapeGen(ShapeSett shapeSettings)
    {
        this.shapeSettings = shapeSettings;
        filterNoise = new INoiseFilter[shapeSettings.NoiseLayers.Length];
        for (int i = 0; i < filterNoise.Length; i++)
        {
            filterNoise[i] = NoiseFilterFactory.CreateNoiseFilter(shapeSettings.NoiseLayers[i].noiseSett);
        }
    }
    public Vector3 CalculatePointOnPlanet(Vector3 pointOnUnitSphere)
    {
        float firstLayerValue = 0;
        float elevation = 0;
        if (filterNoise.Length > 0)
        {
            firstLayerValue = filterNoise[0].Evaluate(pointOnUnitSphere);
            if (shapeSettings.NoiseLayers[0].enabled)
            {
                elevation = firstLayerValue;
            }
        }
        for (int i =0; i< filterNoise.Length; i++)
        {
            if (shapeSettings.NoiseLayers[i].enabled)
            {
                if (shapeSettings.NoiseLayers[i].useFirstLayerAsMask)
                {
                    elevation += filterNoise[i].Evaluate(pointOnUnitSphere) * shapeSettings.NoiseLayers[i].noiseSett.strength;
                }
                else
                {
                    elevation += filterNoise[i].Evaluate(pointOnUnitSphere);
                }
            }
        }
    
        return pointOnUnitSphere * shapeSettings.planetRadius * (1 + elevation);
    }

}
