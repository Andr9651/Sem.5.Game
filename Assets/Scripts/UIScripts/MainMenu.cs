using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[SerializeField] private LevelManager _levelManager;
	[SerializeField] private LevelSelectElement _levelSelectElementPrefab;
	[SerializeField] private Transform _levelSelectContainer;

	private void Start()
	{
		FillLevelSelector();
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