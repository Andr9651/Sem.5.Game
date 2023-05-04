using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private List<ICheckpoint> _checkpoints;
    private HashSet<int> _triggeredCheckpoints;
    private ScoreManager _scoreManager;
    private PlayerDataManager _playerDataManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _checkpoints = new List<ICheckpoint>(FindObjectsOfType<Checkpoint>());
        _triggeredCheckpoints = new HashSet<int>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _playerDataManager = FindObjectOfType<PlayerDataManager>();

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
        _scoreManager.StartTimer();
        print("Ok, let's go!");
    }

    private void OnTriggerGoalHandler(int id)
    {
        _triggeredCheckpoints.Add(id);

        if (_triggeredCheckpoints.Count != _checkpoints.Count) return;
        _scoreManager.StopTimer();
        _triggeredCheckpoints.Clear();
        _playerDataManager.SavePlayerData();
        print("Doners, your time is: " + _scoreManager.GetRaceTime());
    }
}