using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LeaderboardManager : MonoBehaviour
{
	[Header("Leaderboard source reference")]
	[SerializeField] private LeaderboardSourceBase _leaderboardSource;
	
	[Header("Global Variables")]
	[SerializeField] private StringVariable _trackName;

	[Header("Leaderboard UI References")]
	// Prefab for the leaderboard element
	[SerializeField] private LeaderboardElement _scoreListElement;
	[SerializeField] private GameObject _scoreListContainer;
	[SerializeField] private TMP_Text _trackNameText;
	
	
	
	public void UpdateLeaderboard()
	{
		StartCoroutine(_leaderboardSource.GetLeaderboard(FillLeaderboard));
	}

	public void UploadScore()
	{
		StartCoroutine(_leaderboardSource.PostHighScore(UpdateLeaderboard));
	}
	
	private void FillLeaderboard()
	{
		foreach (Transform child in _scoreListContainer.transform)
		{
			Destroy(child.GameObject());
		}
		
		_trackNameText.SetText("Trackname: " + _trackName.Text);
		
		for (int i = 0; i < _leaderboardSource.Leaderboard.Count; i++)
		{
			LeaderboardScore score = _leaderboardSource.Leaderboard[i];
			
			LeaderboardElement element = Instantiate(_scoreListElement, _scoreListContainer.transform);
			element.SetText(i+1, score.PlayerName, score.Time);

			RectTransform rectTransform = element.GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(0, -i * 75);
			
		}
	}
}