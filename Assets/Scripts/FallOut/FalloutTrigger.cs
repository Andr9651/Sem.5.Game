using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FalloutTrigger : MonoBehaviour
    {
        [FormerlySerializedAs("fallOutStrategyBase")] [SerializeField] private FallOutStrategyBase _fallOutStrategy;
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(_fallOutStrategy.HandleFallout(other.gameObject));
        }
    }
