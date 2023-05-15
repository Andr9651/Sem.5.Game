using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.SceneReference;
using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu]
public class LevelManager : ScriptableObject
{
	[field: SerializeField] public List<TrackData> Tracks { get; private set; }

	[SerializeField] private SceneReference MainMenu;
	[SerializeField] private SceneReference UI;
	
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		UI.LoadScene(LoadSceneMode.Additive);
	}

	public void LoadMainMenu()
	{
		MainMenu.LoadScene(LoadSceneMode.Single);
	}

	public void LoadScene(int sceneNumber)
	{
		Tracks[sceneNumber].Scene.LoadScene();
		UI.LoadScene(LoadSceneMode.Additive);
	}
}
