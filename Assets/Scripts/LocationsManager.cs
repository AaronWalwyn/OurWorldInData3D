using System.Collections.Generic;
using UnityEngine;

public class LocationsManager : MonoBehaviour
{
    [SerializeField] private LocationData _locationData;
    [SerializeField] private float _radius = 100f;
    [Space] 
    [SerializeField] private Transform _locationsRoot;
    [SerializeField] private GameObject _template;
    
    // Start is called before the first frame update
    private void Start()
    {
        foreach (var location in _locationData.Locations)
        {
            var localPosition = GetVector3FromLatLon(location.LatLon, _radius + 1f);

            var newGameObject = GameObject.Instantiate(_template, localPosition, Quaternion.identity, _locationsRoot);
            newGameObject.name = location.Name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
        
        foreach (var location in _locationData.Locations)
        {
            Gizmos.DrawSphere(transform.position + GetVector3FromLatLon(location.LatLon, _radius), 5f);
        }
    }
#endif

    public static Vector3 GetVector3FromLatLon (LatLong latlong, float sphereRadius)
    {
        var latitude = Mathf.PI * latlong.Lat / 180f;
        var longitude = Mathf.PI * latlong.Long / 180f;

        // adjust position by radians	
        latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (sphereRadius) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
        float zPos = (sphereRadius) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
        float yPos = (sphereRadius) * Mathf.Cos(latitude);
        
        return new Vector3(xPos, yPos, zPos);
    }
}