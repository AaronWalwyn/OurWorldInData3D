using System;
using UnityEngine;

[Serializable]
public struct LatLong
{
    [SerializeField] public float Lat;
    [SerializeField] public float Long;
        
    public LatLong(float lat, float @long)
    {
        Lat = lat;
        Long = @long;
    }
}