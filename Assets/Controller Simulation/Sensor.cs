using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour
{
    public float rayLength;

    public int value;

    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(_transform.position, -_transform.up);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, rayLength))
        {
            value = hitInfo.collider.name switch
            {
                "Positive" => 1,
                "Negative" => -1,
                _ => 0
            };
        }
        else
        {
            value = 0;
        }
        
        
        
        if(value != 0){
            Debug.DrawLine(_transform.position, _transform.position - transform.up*rayLength,Color.green);
        }
        else
        {
            Debug.DrawLine(_transform.position, _transform.position - transform.up*rayLength,Color.red);
        }
    }

    
}
