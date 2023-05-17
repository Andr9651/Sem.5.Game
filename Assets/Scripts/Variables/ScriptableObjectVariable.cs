using UnityEngine;

public class ScriptableObjectVariable<T> : ScriptableObject
{
	[field: SerializeField] public T Value { get; set; }

	[SerializeField] private bool _dontUnload = false;

	public void SetValue(T newValue)
	{
		Value = newValue;
	}

	private void OnEnable()
	{
		if (_dontUnload)
		{
			hideFlags = HideFlags.DontUnloadUnusedAsset;
		}
	}
}