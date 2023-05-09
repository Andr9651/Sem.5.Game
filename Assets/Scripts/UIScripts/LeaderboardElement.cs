using System;
using TMPro;
using UnityEngine;


public class LeaderboardElement : MonoBehaviour
{
	[SerializeField] private TMP_Text _rankingText;
	[SerializeField] private TMP_Text _playerNameText;
	[SerializeField] private TMP_Text _timeText;
	
	public void SetText(int ranking, string playerName, float time)
	{
		_rankingText.text = $"#{ranking}";
		_playerNameText.text = playerName;
		string formattedTime = TimeSpan.FromSeconds(time).ToString(@"mm\:ss\:fff");
		// https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/manual/RichTextMonospace.html
		_timeText.text = $"<mspace=0.6em>{formattedTime}";
	}
}