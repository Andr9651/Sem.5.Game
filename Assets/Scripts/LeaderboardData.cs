using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class LeaderboardData : ScriptableObject
{
	[FormerlySerializedAs("_leaderboard")] public List<LeaderboardScore> Leaderboard;
}

[Serializable]
public class LeaderboardScore
{
	public float Time;
	public string PlayerName;
	public string TrackName;
}