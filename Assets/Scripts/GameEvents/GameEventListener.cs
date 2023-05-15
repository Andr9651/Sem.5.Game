using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class GameEventListener : MonoBehaviour
{
	public GameEvent Event;
	
	[SerializeField]
	private bool _printDebugMessage;
	
	[EnableIf(nameof(_printDebugMessage))] 
	[SerializeField]
	private string _debugMessage;

	public UnityEvent Response;

	private void OnEnable()
	{
		Event.RegisterListener(this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener(this);
	}

	public void OnEventRaised()
	{
		if (_printDebugMessage)
		{
			print(_debugMessage);
		}

		Response.Invoke();
	}
}