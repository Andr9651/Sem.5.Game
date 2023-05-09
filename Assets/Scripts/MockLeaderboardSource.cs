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
		LeaderboardData._leaderboard = scores.ConvertAll<PlayerTrackTime>((mockScore) =>
		{
			var a = CreateInstance<PlayerTrackTime>();
			a.PlayerName = mockScore.name;
			a.Time = mockScore.time;
			a.TrackName = mockScore.track;
			return a;
		}).OrderBy((_playerTrackTime) => _playerTrackTime.Time)
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