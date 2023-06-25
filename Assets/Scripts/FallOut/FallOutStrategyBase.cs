using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallOutStrategyBase : ScriptableObject
{
    public abstract IEnumerator HandleFallout(GameObject gameObject);
}