using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Diagnostics;

public class TrackManager : MonoBehaviour
{
	[Header("Global Variables")] [SerializeField]
	private FloatVariable _playerTrackTime;

	[SerializeField] private StringVariable _trackName;
	[SerializeField] private TrackData _trackData;

	[Header("GameObject References")] [SerializeField]
	private Rigidbody _player;

	[Header("Events")] [SerializeField] private UnityEvent _onTrackFinish;

	private int _playerLapCount;
	private List<ICheckpoint> _checkpoints;
	private HashSet<int> _triggeredCheckpoints;
	private ICheckpoint _lastTriggeredCheckpoint;

	private Stopwatch _timer;
	private float _startTime;
	private float _endTime;

	// Start is called before the first frame update
	private void Start()
	{
		_trackName.Value = _trackData.Name;
		_timer = new Stopwatch();
		FindCheckpoints();
	}

	private void Update()
	{
		UpdatePlayerTrackTime();
	}

	private void FindCheckpoints()
	{
		_triggeredCheckpoints = new HashSet<int>();

		_checkpoints = new List<ICheckpoint>(FindObjectsOfType<CheckpointBase>());

		for (int i = 0; i < _checkpoints.Count; i++)
		{
			ICheckpoint checkpoint = _checkpoints[i];

			_checkpoints[i].SetId(i);

			switch (checkpoint)
			{
				case StartCheckpoint:
					checkpoint.OnTriggerCheckpoint += OnTriggerStartHandler;
					_lastTriggeredCheckpoint = checkpoint;
					break;

				case GoalCheckpoint:
					checkpoint.OnTriggerCheckpoint += OnTriggerGoalHandler;
					break;

				default:
					checkpoint.OnTriggerCheckpoint += OnTriggerCheckpointHandler;
					break;
			}
		}
	}

	private void OnTriggerCheckpointHandler(int id)
	{
		// return if the checkpoint is already triggered
		if (!_triggeredCheckpoints.Add(id)) return;
		_lastTriggeredCheckpoint = _checkpoints[id];
		print(id);
	}

	private void OnTriggerStartHandler(int id)
	{
		// return if the checkpoint is already triggered
		if (!_triggeredCheckpoints.Add(id)) return;
		_lastTriggeredCheckpoint = _checkpoints[id];
		print(id);

		// Return if the lap count is above 0
		// as the timer should only be started on the first lap
		if (_playerLapCount > 0) return;
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
		StopTimer();
		_onTrackFinish.Invoke();
	}

	public void StartTimer()
	{
		_timer.Start();
	}

	private void UpdatePlayerTrackTime()
	{
		float raceTime = _timer.ElapsedMilliseconds / 1000f;
		_playerTrackTime.Value = raceTime;
	}

	public void StopTimer()
	{
		_timer.Stop();
		UpdatePlayerTrackTime();
	}

	public void SetPlayerPositionToLastCheckpoint()
	{
		_player.transform.SetPositionAndRotation(_lastTriggeredCheckpoint.Transform.position,
			_lastTriggeredCheckpoint.Transform.rotation);
		_player.velocity = Vector3.zero;
		_player.angularVelocity = Vector3.zero;
	}
}