using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    //private string playerDataPath = Application.persistentDataPath;
    private string _playerDataFilePath;

    private PlayerData _playerData;

    private void Start()
    {
        _playerDataFilePath = Path.Combine(Application.persistentDataPath, "playerData.txt");
        _playerData = FindObjectOfType<PlayerData>();
    }

    public void SavePlayerData()
    {
        string jsonData = JsonUtility.ToJson(_playerData);
        
        File.WriteAllText(_playerDataFilePath, jsonData);
    }
}
