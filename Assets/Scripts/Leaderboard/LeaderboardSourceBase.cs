using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LeaderboardSourceBase : ScriptableObject
{
	public List<LeaderboardScore> Leaderboard;
	[SerializeField] protected PlayerTrackTime _playerTrackTime;
	public abstract IEnumerator GetLeaderboard(Action callback);
	public abstract IEnumerator PostHighScore(Action callback);
}

[Serializable]
public class LeaderboardScore
{
	public float Time;
	public string PlayerName;
	public string TrackName;
}