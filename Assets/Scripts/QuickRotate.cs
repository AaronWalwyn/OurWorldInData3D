using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(-transform.up, Time.deltaTime * _rotationSpeed);
    }
}
