using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu]
public class LeaderboardData : ScriptableObject
{
	public List<PlayerTrackTime> _leaderboard;
}