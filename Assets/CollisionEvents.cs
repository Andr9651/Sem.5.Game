using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvents : MonoBehaviour
{
	public UnityEvent OnTriggerEnterEvent;
	public void OnTriggerEnter(Collider other)
	{
		OnTriggerEnterEvent.Invoke();
	}
}
