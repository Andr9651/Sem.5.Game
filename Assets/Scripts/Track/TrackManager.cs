using System;
using System.Collections.Generic;
using Sem5.EventBus;
using UnityEngine;
using UnityEngine.Serialization;

public class TrackManager : MonoBehaviour
{
    private List<ICheckpoint> _checkpoints;
    [FormerlySerializedAs("_lapCount")] [SerializeField] private int _playerLapCount;
    [SerializeField] private int _trackLapCount;
    
    private HashSet<int> _triggeredCheckpoints;
    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = EventBus.Instance;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _checkpoints = new List<ICheckpoint>(FindObjectsOfType<Checkpoint>());
        _triggeredCheckpoints = new HashSet<int>();

        for (int i = 0; i < _checkpoints.Count; i++)
        {
            _checkpoints[i].SetId(i + 1);
            _checkpoints[i].OnTriggerCheckpoint += OnTriggerCheckpointHandler;
        }

        Goal goal = FindObjectOfType<Goal>();

        goal.SetId(_checkpoints.Count + 1);
        goal.OnTriggerCheckpoint += OnTriggerGoalHandler;

        _checkpoints.Add(goal);

        Start start = FindObjectOfType<Start>();

        start.SetId(0);
        start.OnTriggerCheckpoint += OnTriggerStartHandler;

        _checkpoints.Add(start);
    }

    private void OnTriggerCheckpointHandler(int id)
    {
        _triggeredCheckpoints.Add(id);
    }

    private void OnTriggerStartHandler(int id)
    {
        if (!_triggeredCheckpoints.Add(id)) return;
        _eventBus.InvokeOnStartRace();
        print("Ok, let's go!");
    }

    private void OnTriggerGoalHandler(int id)
    {
        _triggeredCheckpoints.Add(id);
        
        if (_triggeredCheckpoints.Count != _checkpoints.Count) return;
        _playerLapCount++;
        _triggeredCheckpoints.Clear();

        if (_playerLapCount < _trackLapCount) return;
        _eventBus.InvokeOnFinishRace();
    }
}