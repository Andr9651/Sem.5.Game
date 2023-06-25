using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseInputProcessor : ScriptableObject
{
	protected float _leftWheelInput;
	protected float _rightWheelInput;

	public float LeftWheelInput
	{
		get => ProcessInput(_leftWheelInput);
		set => _leftWheelInput = value;
	}

	public float RightWheelInput
	{
		get => ProcessInput(_rightWheelInput);
		set => _rightWheelInput = value;
	}


	protected virtual float ProcessInput(float input)
	{
		return input;
	}

}