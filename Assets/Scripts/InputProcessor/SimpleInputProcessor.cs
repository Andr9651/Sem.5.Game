using UnityEngine;

[CreateAssetMenu]
public class SimpleInputProcessor : BaseInputProcessor
{
	[field: SerializeField] public float MaximumStraightDelta { get; set; }

	protected override float ProcessInput(float input)
	{
		if (Mathf.Sign(_leftWheelInput) == Mathf.Sign(_rightWheelInput))
		{
			if (Mathf.Abs(_leftWheelInput - _rightWheelInput) < MaximumStraightDelta)
			{
				Debug.Log("corrected");
				return (_leftWheelInput + _rightWheelInput) / 2f;
			}
		}
		
		return input;
	}
}