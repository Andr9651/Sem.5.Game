using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.SceneReference;
using UnityEngine.SceneManagement;
using UnityEngine;

[CreateAssetMenu]
public class LevelManager : ScriptableObject
{
	public List<SceneReference> Tracks;

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
		Tracks[sceneNumber].LoadScene();
		UI.LoadScene(LoadSceneMode.Additive);
	}
}
