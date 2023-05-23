using System;
using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool _isPaused;
    [SerializeField] private GameEvent _OnPauseGameEvent;
    [SerializeField] private GameEvent _OnUnpauseGameEvent;
    
    void OnPause()
    {
        PauseGame();

    }

    private void PauseGame()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            Time.timeScale = 0;
            _OnPauseGameEvent.Raise();
        }
        else
        {
            Time.timeScale = 1;
            _OnUnpauseGameEvent.Raise();
        }
    }

    public void PauseGameNoEvents( bool shouldPause)
    {
        _isPaused = shouldPause;
        if (_isPaused)
        {
            Time.timeScale = 0;
            
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    
}