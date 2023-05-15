using RoboRyanTron.SceneReference;
using UnityEngine;

[CreateAssetMenu]
public class TrackData: ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int LapCount { get; private set; }
    [field: SerializeField] public float AuthorTime { get; private set; }
    [field: SerializeField] public SceneReference Scene { get; private set; }
    
        
}