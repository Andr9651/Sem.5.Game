using System;
using System.IO;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu]
public class SaveDataManagerBase: ScriptableObject
{
    public FloatVariable playerTrackTime;
    [Button]
    public bool SavePlayerTrackData()
    {
        string json = JsonUtility.ToJson(playerTrackTime, true);
        string playerDataPath = Path.Combine(Application.persistentDataPath, "playerData.txt");
        
        try
        {        
            File.WriteAllText(playerDataPath, json);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
            return false;
        }
        
        return true;
    }
}