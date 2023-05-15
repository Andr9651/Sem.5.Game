using System;
using TMPro;
using UnityEngine;

public class LevelSelectElement: MonoBehaviour
{
	private TrackData _trackData;
	private TMP_Text _text;

	private void Awake()
	{
		_text = GetComponentInChildren<TMP_Text>();
	}

	public void SetTrackData(TrackData trackData)
	{
		_trackData = trackData;
		_text.text = trackData.Name;
	}
	
	
}