using System.Collections.Generic;
using Sem5.EventBus;
using UnityEngine;
using UnityEngine.Events;

public class TrackManager : MonoBehaviour
{
    private List<ICheckpoint> _checkpoints;
    [SerializeField] private int _playerLapCount;
    [SerializeField] private PlayerTrackTime _playerTrackTime;
    [SerializeField] private TrackData _trackData;
    [SerializeReference] [SerializeField] private ICheckpoint _checkpoint;
    [SerializeField]private UnityEvent OnTrackFinish;

    private HashSet<int> _triggeredCheckpoints;
    private EventBus _eventBus;
    private float _startTime;
    private float _endTime;


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

        _playerTrackTime.TrackName = _trackData.Name;

        _checkpoints.Add(start);
    }

    private void OnTriggerCheckpointHandler(int id)
    {
        _triggeredCheckpoints.Add(id);
    }

    private void OnTriggerStartHandler(int id)
    {
        if (!_triggeredCheckpoints.Add(id) || _playerLapCount != 0) return;
        StartTimer();
        print("Ok, let's go!");
    }

    private void OnTriggerGoalHandler(int id)
    {
        _triggeredCheckpoints.Add(id);

        if (_triggeredCheckpoints.Count != _checkpoints.Count) return;
        _playerLapCount++;
        _triggeredCheckpoints.Clear();

        if (_playerLapCount < _trackData.LapCount) return;
        OnTrackFinish.Invoke();
        StopTimer();
    }

    private void StartTimer()
    {
        _startTime = Time.time;
    }

    private void StopTimer()
    {
        _endTime = Time.time;

        float raceTime = _endTime - _startTime;

        _playerTrackTime.Time = raceTime;
        print(raceTime);
    }
}