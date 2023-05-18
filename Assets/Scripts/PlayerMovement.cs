using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [Header("Global variables")]
    [SerializeField] private FloatVariable _maxSpeed;
    [Header("GameObject references")]
    [SerializeField] private WheelCollider _leftWheelCollider;
    [SerializeField] private WheelCollider _rightWheelCollider;
    [SerializeField] private Transform _leftWheel;
    [SerializeField] private Transform _rightWheel;

    private float _leftWheelInput;
    private float _rightWheelInput;

    private Rigidbody _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos;
        Quaternion rotation;
        
        _leftWheelCollider.GetWorldPose(out pos, out rotation);
        _leftWheel.SetPositionAndRotation(pos,rotation);
        
        _rightWheelCollider.GetWorldPose(out pos, out rotation);
        _rightWheel.SetPositionAndRotation(pos,rotation);
    }

    private void FixedUpdate()
    {
        _rigidbody.WakeUp();
        
        _leftWheelCollider.rotationSpeed = _maxSpeed.Value * _leftWheelInput;
        _rightWheelCollider.rotationSpeed = _maxSpeed.Value * _rightWheelInput;
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
