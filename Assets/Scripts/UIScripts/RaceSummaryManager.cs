using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;
using TMPro;

public class RaceSummaryManager : MonoBehaviour
{
	[SerializeField] private TMP_Text _timeText;
	[SerializeField] private FloatVariable _playerTrackTime;
	
	
	public void UpdateTimeText()
	{
		string formattedTime = FormattingHelper.FormatFloatToTime(_playerTrackTime.Value);
		_timeText.SetText(formattedTime);
	}
}
