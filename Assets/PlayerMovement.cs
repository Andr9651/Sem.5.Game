using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private WheelCollider _leftWheel;
    [SerializeField] private WheelCollider _rightWheel;

    private float _leftWheelInput;
    private float _rightWheelInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _leftWheel.motorTorque = 0;
        _rightWheel.motorTorque = 0;
        _leftWheel.rotationSpeed = 720 * _leftWheelInput;
        _rightWheel.rotationSpeed = 720 * _rightWheelInput;
        
        // print(_leftWheel.rpm);
    }

    void OnLeftWheel(InputValue inputValue)
    {
        _leftWheelInput = inputValue.Get<float>();
    }

    void OnRightWheel(InputValue inputValue)
    {
        _rightWheelInput = inputValue.Get<float>(); 
    }
}
