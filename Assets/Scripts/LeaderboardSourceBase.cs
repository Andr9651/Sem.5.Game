using System;
using System.Collections;
using UnityEngine;

public abstract class LeaderboardSourceBase : ScriptableObject
{
	[SerializeField] protected PlayerTrackTime _playerTrackTime;
	[field: SerializeField] public LeaderboardData LeaderboardData { get; set; }
	public abstract IEnumerator GetLeaderboard(Action callback);
	public abstract IEnumerator PostHighscore(Action callback);
}