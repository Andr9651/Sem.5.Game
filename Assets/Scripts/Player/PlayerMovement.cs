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
    [SerializeField] private BaseInputProcessor _inputProcessor;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (_inputProcessor == null)
        {
            _inputProcessor = ScriptableObject.CreateInstance<BaseInputProcessor>();
        }
    }

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

    // Fixed update is called once every physics update (50 times per second)
    private void FixedUpdate()
    {
        _rigidbody.WakeUp();
        
        _leftWheelCollider.rotationSpeed = _maxSpeed.Value * _inputProcessor.LeftWheelInput;
        _rightWheelCollider.rotationSpeed = _maxSpeed.Value * _inputProcessor.RightWheelInput;
    }

    void OnLeftWheel(InputValue inputValue)
    {
        _inputProcessor.LeftWheelInput = inputValue.Get<float>();
    }

    void OnRightWheel(InputValue inputValue)
    {
        _inputProcessor.RightWheelInput = inputValue.Get<float>();

    }
}
