using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TireHeating : MonoBehaviour
{
    [SerializeField] private MeshRenderer _leftTireRubber;
    [SerializeField] private MeshRenderer _rightTireRubber;
    [SerializeField] private ParticleSystem _leftTireSmoke;
    [SerializeField] private ParticleSystem _rightTireSmoke;
    
    [SerializeField] private Color _heatColor;
    
    
    private float _leftWheelInput;
    private float _rightWheelInput;
    private Color _baseColor;

    // Start is called before the first frame update
    void Start()
    {
        _baseColor = _rightTireRubber.sharedMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        float leftLerpT = Mathf.Pow(Mathf.Abs(_leftWheelInput), 3);
        _leftTireRubber.material.color = Color.Lerp(_baseColor, _heatColor, leftLerpT);
        
        float rightLerpT = Mathf.Pow(Mathf.Abs(_rightWheelInput), 3);
        _rightTireRubber.material.color = Color.Lerp(_baseColor, _heatColor, rightLerpT);

        if (Mathf.Abs(_leftWheelInput) == 1)
        {
            if (!_leftTireSmoke.isPlaying)
            {
                _leftTireSmoke.Play();
            }
        }
        else
        {
            _leftTireSmoke.Stop();
        }
        
        if (Mathf.Abs(_rightWheelInput) == 1)
        {
            if (!_rightTireSmoke.isPlaying)
            {
                _rightTireSmoke.Play();
            }
        }
        else
        {
            _rightTireSmoke.Stop();
        }
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
