using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class LeaderboardManager : MonoBehaviour
{
	[SerializeField] private LeaderboardSourceBase _leaderboardSource;
	[SerializeField] private GameObject _scoreListContainer;

	// Prefab for the leaderboard element
	[SerializeField] private LeaderboardElement _scoreListElement;


	public void UpdateLeaderboard()
	{
		StartCoroutine(_leaderboardSource.GetLeaderboard(FillLeaderboard));
	}

	private void FillLeaderboard()
	{
		foreach (Transform child in _scoreListContainer.transform)
		{
			Destroy(child.GameObject());
		}
		
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