using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Sem5.EventBus;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private EventBus _eventBus;

    private float _startTime;
    private float _endTime;

    // Gets called when the component is created, but before OnEnable
    private void Awake()
    {
        _eventBus = EventBus.Instance;
    }

    // Gets called when the component is enabled or created
    private void OnEnable()
    {
        // Unsubscribe just in case it was already subscribed
        _eventBus.OnStartRace -= StartTimer;
        _eventBus.OnStartRace += StartTimer;

        _eventBus.OnFinishRace -= StopTimer;
        _eventBus.OnFinishRace += StopTimer;
    }

    // Gets called when the component is disabled or destroyed
    private void OnDisable()
    {
        _eventBus.OnStartRace -= StartTimer;
        _eventBus.OnFinishRace -= StopTimer;
    }

    private void StartTimer()
    {
        _startTime = Time.time;
    }

    private void StopTimer()
    {
        _endTime = Time.time;

        float raceTime = _endTime - _startTime;
        print(raceTime);
        _eventBus.InvokeOnTrackTimeUpdate(raceTime);
    }
}