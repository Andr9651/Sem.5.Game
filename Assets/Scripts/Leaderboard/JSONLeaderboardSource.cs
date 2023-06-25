using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class JsonLeaderboardSource : LeaderboardSourceBase
{
	[Multiline(lines:20)]
	public string Json;
	public override IEnumerator GetLeaderboard(Action callback)
	{
		LeaderboardScore[] scores = JsonUtilityHelpers.FromJsonArray<LeaderboardScore>(Json);
		Leaderboard = scores.ToList();
		
		callback?.Invoke();
		yield break;
	}

	public override IEnumerator PostHighScore(Action callback)
	{
		throw new NotImplementedException();
	}
}