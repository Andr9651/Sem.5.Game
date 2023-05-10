using System;
using UnityEngine;

public static class JsonUtilityHelpers
{
	public static T[] FromJsonArray<T>(string json)
	{
		string wrappedJson = "{\"Array\":" + json + "}";
		ArrayWrapper<T> arrayWrapper = JsonUtility.FromJson<ArrayWrapper<T>>(wrappedJson);
		return arrayWrapper.Array;
	}

	[Serializable]
	internal class ArrayWrapper<T>
	{
		public T[] Array;
	}
}