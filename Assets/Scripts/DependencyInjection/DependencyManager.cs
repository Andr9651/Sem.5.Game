using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DependencyInjection
{
    public static class DependencyManager
    {
        private static Dictionary<Type, MonoBehaviourDependency> _dependencyContainer;
        private static Dictionary<Type, MonoBehaviourDependency> _uninstanciatedManagers;

        private static event Action _test;

        private static string _dependencyPath = "Dependencies";

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void LoadDependencies()
        {
            _dependencyContainer = new Dictionary<Type, MonoBehaviourDependency>();
            _uninstanciatedManagers = new Dictionary<Type, MonoBehaviourDependency>();

            var foundDependencies = Resources.LoadAll<MonoBehaviourDependency>(_dependencyPath);
            
            _uninstanciatedManagers = foundDependencies.ToDictionary(dependency => dependency.GetType());
        }
        
        public static T GetDependency<T>() where T : MonoBehaviourDependency
        {
            if (_dependencyContainer.TryGetValue(typeof(T), out MonoBehaviourDependency dependency))
            {
                return (T)dependency;
            }

            if (_uninstanciatedManagers.TryGetValue(typeof(T), out MonoBehaviourDependency newDependency))
            {
                MonoBehaviourDependency instantiatedDependency = GameObject.Instantiate(newDependency);
                
                // ResolveDependencies might need to happen elsewhere see:
                // https://gamedev.stackexchange.com/questions/135895/what-is-the-order-of-execution-when-calling-an-instantiation-method-in-unity
                instantiatedDependency.ResolveDependencies();
                
                _dependencyContainer.Add(typeof(T), instantiatedDependency);
                return (T)instantiatedDependency;
            }

            throw new Exception($"The dependency {typeof(T)} was not found in \"Resources\\{_dependencyPath}\"");
        }
    }
}