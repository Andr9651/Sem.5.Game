using System;
using UnityEngine;

    public class FalloutTrigger : MonoBehaviour
    {
        [SerializeField] private FallOutStrategy _fallOutStrategy;
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(_fallOutStrategy.HandleFallout(other.gameObject));
        }
    }
