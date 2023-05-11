using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class MockLeaderboardSource : LeaderboardSourceBase
{
	[SerializeField] private List<LeaderboardScore> scores;

	public override IEnumerator GetLeaderboard(Action callback)
	{
		yield return new WaitForSeconds(1f);
		Leaderboard = scores
			.OrderBy((leaderboardScore) => leaderboardScore.Time)
			.ToList();

		callback?.Invoke();
	}

	public override IEnumerator PostHighScore(Action callback)
	{
		yield return new WaitForSeconds(1f);
		callback?.Invoke();
	}
}