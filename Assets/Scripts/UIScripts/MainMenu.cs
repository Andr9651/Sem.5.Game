using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[Header("Level Selector Settings")]
	[SerializeField] private LevelManager _levelManager;
	[SerializeField] private LevelSelectElement _levelSelectElementPrefab;
	[SerializeField] private Transform _levelSelectContainer;
	[Header("Player Name Input Field Settings")]
	[SerializeField] private TMP_InputField _playerNameInputField;
	[SerializeField] private StringVariable _playerNameVariable;
	

	private void Start()
	{
		FillLevelSelector();
		FillPlayerNameInputField();
	}

	private void FillPlayerNameInputField()
	{
		_playerNameInputField.text = _playerNameVariable.Value;
	}

	private void FillLevelSelector()
	{
		foreach (TrackData trackData in _levelManager.Tracks)
		{
			LevelSelectElement newElement = Instantiate(_levelSelectElementPrefab, _levelSelectContainer);
			newElement.SetTrackData(trackData);
		}
	}
}