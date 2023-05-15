using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSelectElement : MonoBehaviour
{
	[SerializeField] private LevelManager _levelManager;
	private TrackData _trackData;
	private TMP_Text _text;
	private Button _button;


	private void Awake()
	{
		_text = GetComponentInChildren<TMP_Text>();
		_button = GetComponent<Button>();
	}

	public void SetTrackData(TrackData trackData)
	{
		_trackData = trackData;
		_text.text = trackData.Name;
		_button.onClick.AddListener(() => _levelManager.LoadTrack(trackData));
	}
}