using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using TMPro;

public class RaceSummaryManager : MonoBehaviour
{
	[Header("UI References")]
	[SerializeField] private TMP_Text _timeText;
	[SerializeField] private TMP_Text _playerNameText;
	[Header("Global Variables")]
	[SerializeField] private FloatVariable _playerTrackTime;
	[SerializeField] private StringVariable _playerName;
	
	
	public void UpdateTimeText()
	{
		string formattedTime = FormattingHelper.FormatFloatToTime(_playerTrackTime.Value);
		_timeText.SetText(formattedTime);
	}

	public void UpdatePlayerNameText()
	{
		_playerNameText.text = "by: " +_playerName.Value;
	}
}
