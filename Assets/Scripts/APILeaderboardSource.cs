﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.Serialization;

// https://docs.unity3d.com/2022.2/Documentation/ScriptReference/Networking.UnityWebRequest.Get.html
[CreateAssetMenu]
public class APILeaderboardSource : LeaderboardSourceBase
{
	[SerializeField] private string _leaderboardUri;

	public override IEnumerator GetLeaderboard(Action callback)
	{
		using (UnityWebRequest request = UnityWebRequest.Get(_leaderboardUri))
		{
			yield return request.SendWebRequest();

			if (request.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError(request.error);
				yield break;
			}

			string json = request.downloadHandler.text;
			LeaderboardScore[] scores = JsonUtilityHelpers.FromJsonArray<LeaderboardScore>(json);
			
			LeaderboardData ??= CreateInstance<LeaderboardData>();
			LeaderboardData.Leaderboard = scores.ToList();
		}

		callback?.Invoke();
	}

	public override IEnumerator PostHighscore(Action callback)
	{
		string json = JsonUtility.ToJson(_playerTrackTime);
		using (UnityWebRequest request = UnityWebRequest.Post(_leaderboardUri, json, "application/json"))
		{
			yield return request.SendWebRequest();

			if (request.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError(request.error);
			}
		}

		callback?.Invoke();
	}
}