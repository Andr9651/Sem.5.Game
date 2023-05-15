using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace Editor
{
	[InitializeOnLoad]
	public class OnPlay
	{
		static OnPlay()
		{
			EditorApplication.playModeStateChanged += LoadUIOnTrackScene;
		}

		static void LoadUIOnTrackScene(PlayModeStateChange stateChange)
		{
			if (stateChange == PlayModeStateChange.EnteredPlayMode)
			{
				string currentSceneName = SceneManager.GetActiveScene().name;
				if (currentSceneName.Contains("Track"))
				{
					// Loads the scene with index 1 as seen in "File/Build Settings..."
					SceneManager.LoadScene(1, LoadSceneMode.Additive);
				}
			}
			
		}
	}
}