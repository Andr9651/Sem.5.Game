using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field:SerializeField] public float RaceTime { get; private set; }

    public void SetRaceTime(float raceTime)
    {
        this.RaceTime = raceTime;
    }
}
