using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float _startTime;
    private float _endTime;
    
    public void StartTimer()
    {
        _startTime = Time.time;
    }

    public void StopTimer()
    {
        _endTime = Time.time;
    }

    public float GetRaceTime()
    {
        return _endTime - _startTime;
    }
    
}
