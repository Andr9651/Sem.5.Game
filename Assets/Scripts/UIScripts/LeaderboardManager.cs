
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class LeaderboardManager : MonoBehaviour
{
	[FormerlySerializedAs("_leaderboardSource")] [Header("Leaderboard source reference")]
	public LeaderboardSourceBase leaderboardSource;
	
	[Header("Global Variables")]
	[SerializeField] private StringVariable _trackName;

	[Header("Leaderboard UI References")]
	// Prefab for the leaderboard element
	[SerializeField] private LeaderboardElement _scoreListElement;
	[SerializeField] private GameObject _scoreListContainer;
	[SerializeField] private TMP_Text _trackNameText;
	
	
	
	public void UpdateLeaderboard()
	{
		StartCoroutine(leaderboardSource.GetLeaderboard(FillLeaderboard));
	}

	public void UploadScore()
	{
		StartCoroutine(leaderboardSource.PostHighScore(UpdateLeaderboard));
	}
	
	private void FillLeaderboard()
	{
		foreach (Transform child in _scoreListContainer.transform)
		{
			Destroy(child.gameObject);
		}
		
		_trackNameText.SetText("Trackname: " + _trackName.Value);
		
		for (int i = 0; i < leaderboardSource.Leaderboard.Count; i++)
		{
			LeaderboardScore score = leaderboardSource.Leaderboard[i];
			
			LeaderboardElement element = Instantiate(_scoreListElement, _scoreListContainer.transform);
			element.SetText(i+1, score.PlayerName, score.Time);

			RectTransform rectTransform = element.GetComponent<RectTransform>();
			rectTransform.anchoredPosition = new Vector2(0, -i * 75);
			
		}
	}
}