using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(LocationData), menuName = "ScriptableObjects/LocationData", order = 1)]
public class LocationData : ScriptableObject
{
    public IReadOnlyList<Location> Locations => _locations;
    
    [SerializeField] private List<Location> _locations = new List<Location>();
    
#if UNITY_EDITOR
    // Add a menu item named "Do Something" to MyMenu in the menu bar.
    [MenuItem("WorldInData/Location Data/Parse counties_lat_long.csv")]
    static void DoSomething()
    {
        var newData = ScriptableObject.CreateInstance<LocationData>();
        
        StreamReader reader = File.OpenText("Assets/Data/Raw/countries_lat_long.csv");
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            var split = line.Split(',');
            
            if (string.IsNullOrWhiteSpace(split[0]))
            {
                continue;
            }
            
            if(!float.TryParse(split[1], out var lat))
            {
                continue;
            }
            
            if(!float.TryParse(split[2], out var @long))
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(split[3]))
            {
                continue;
            }
            
            newData._locations.Add(new Location()
            {
                Code = split[0],
                Name = split[3],
                LatLon = new LatLong(lat, @long),
            });
        }
        
        AssetDatabase.CreateAsset (newData, "Assets/Data/CountryLocationData.asset");
    }
#endif
}