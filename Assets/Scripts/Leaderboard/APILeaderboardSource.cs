using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

	private string GetCompleteUri()
	{
		
		return new Uri(Path.Combine(_leaderboardUri, _trackName.Text)).AbsoluteUri;
	}
	
	public override IEnumerator GetLeaderboard(Action callback)
	{
		string completeUri = GetCompleteUri();
		
		Debug.Log(completeUri);
		
		using (UnityWebRequest request = UnityWebRequest.Get(completeUri))
		{
			yield return request.SendWebRequest();

			if (request.result != UnityWebRequest.Result.Success)
			{
				Debug.LogError(request.error);
				yield break;
			}

			string json = request.downloadHandler.text;
			LeaderboardScore[] scores = JsonUtilityHelpers.FromJsonArray<LeaderboardScore>(json);
			Leaderboard = scores.ToList();
		}

		callback?.Invoke();
	}

	public override IEnumerator PostHighScore(Action callback)
	{
		string completeUri = GetCompleteUri();

		string json = JsonUtility.ToJson(_playerTrackTime);
		using (UnityWebRequest request = UnityWebRequest.Post(completeUri, json, "application/json"))
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