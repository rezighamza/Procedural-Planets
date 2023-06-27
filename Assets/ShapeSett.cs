using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShapeSett : ScriptableObject {

    public float planetRadius = 1;
    public NoiseLayer[] NoiseLayers;
    [System.Serializable]
    public class NoiseLayer
    {
        public bool enabled = true;
        public bool useFirstLayerAsMask;
        public NoiseSett noiseSett;
    }
}

