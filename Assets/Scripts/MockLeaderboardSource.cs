using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class MockLeaderboardSource : LeaderboardSourceBase
{
	[SerializeField] private List<MockScore> scores;

	public override IEnumerator GetLeaderboard(Action callback)
	{
		yield return new WaitForSeconds(1f);
		LeaderboardData.Leaderboard = scores.ConvertAll<LeaderboardScore>((mockScore) =>
			{
				var score = new LeaderboardScore();
				score.PlayerName = mockScore.name;
				score.Time = mockScore.time;
				score.TrackName = mockScore.track;
				return score;
			})
			.OrderBy((leaderboardScore) => leaderboardScore.Time)
			.ToList();

		callback?.Invoke();
	}

	public override IEnumerator PostHighscore(Action callback)
	{
		yield return new WaitForSeconds(1f);
		callback?.Invoke();
	}

	[Serializable]
	private class MockScore
	{
		public float time;
		public string name;
		public string track;
	}
}