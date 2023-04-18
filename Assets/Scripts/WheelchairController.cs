using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelchairController : MonoBehaviour
{
    [SerializeField] private Transform _leftWheel;
    [SerializeField] private Transform _rightWheel;

    private CharacterController _characterController;

    private float _leftInput;
    private float _rightInput;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _rightWheel.Rotate(Vector3.down, _leftInput);
        _leftWheel.Rotate(Vector3.down, _rightInput);

        float centerPointRatio = (Mathf.Abs(_leftInput) - Mathf.Abs(_rightInput)+1)/2;
        print(centerPointRatio);
        
        //_characterController.Move()
    }

    public void OnRightWheel(InputValue value)
    {
        _rightInput = value.Get<float>();
    }
    
    public void OnLeftWheel(InputValue value)
    {
        _leftInput = value.Get<float>();
    }
}
