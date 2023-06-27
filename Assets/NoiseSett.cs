using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NoiseSett
{
    public enum FilterType { Ridgid, Filter};
    public FilterType filterType;
    public float strength = 1;
    public float roughness = 2;
    public Vector3 center;
    [Range(1,8)]
    public int numLayers = 1;
    public float persistance = .5f;
    public float baseRoughness = 1;
    public float minValue;
    public float weightMultiplier = .8f;
    
}

