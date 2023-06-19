using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallOutStrategy : ScriptableObject
{
    public abstract IEnumerator HandleFallout(GameObject gameObject);
}