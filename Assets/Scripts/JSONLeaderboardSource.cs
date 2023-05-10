using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu]
class JSONLeaderboardSource : LeaderboardSourceBase
{
	[Multiline(lines:20)]
	public string Json;
	public override IEnumerator GetLeaderboard(Action callback)
	{
		
		LeaderboardData ??= CreateInstance<LeaderboardData>();
		JsonUtility.FromJsonOverwrite(Json, LeaderboardData);
		
		callback?.Invoke();
		yield break;
	}

	public override IEnumerator PostHighscore(Action callback)
	{
		throw new NotImplementedException();
	}
}