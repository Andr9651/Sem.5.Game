using UnityEngine;

[CreateAssetMenu]
public class TrackData: ScriptableObject
{
    [field: SerializeField]public string Name { get; private set; }
    public int LapCount;
    public float AuthorTime;
        
}