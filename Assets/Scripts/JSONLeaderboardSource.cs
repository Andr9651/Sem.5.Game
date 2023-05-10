using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu]
public class JsonLeaderboardSource : LeaderboardSourceBase
{
	[Multiline(lines:20)]
	public string Json;
	public override IEnumerator GetLeaderboard(Action callback)
	{
		
		LeaderboardData ??= CreateInstance<LeaderboardData>();
		LeaderboardScore[] scores = JsonUtilityHelpers.FromJsonArray<LeaderboardScore>(Json);

		LeaderboardData.Leaderboard = scores.ToList();
		
		callback?.Invoke();
		yield break;
	}

	public override IEnumerator PostHighscore(Action callback)
	{
		throw new NotImplementedException();
	}
}