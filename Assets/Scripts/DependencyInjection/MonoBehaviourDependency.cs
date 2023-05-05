using System;
using UnityEngine;

namespace DependencyInjection
{
    public abstract class MonoBehaviourDependency : MonoBehaviour
    {
        internal abstract void ResolveDependencies();
    }
}