using System;
using UnityEngine;

[Serializable]
public class Location
{
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public LatLong LatLon
    {
        get => _latLon;
        set => _latLon = value;
    }

    public string Code
    {
        get => _code;
        set => _code = value;
    }

    [SerializeField] private string _code;
    [SerializeField] private string _name;
    [SerializeField] private LatLong _latLon;
}