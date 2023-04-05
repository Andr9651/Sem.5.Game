using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpin : MonoBehaviour
{
    public float velocity;
    public float acceleration;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity += Input.GetAxisRaw("Horizontal") * Time.deltaTime * -acceleration;


    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, velocity);
    }
}
