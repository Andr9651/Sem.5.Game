using UnityEngine;

[CreateAssetMenu]
public class StringVariable : ScriptableObject
{
	public string Text;

	public void SetText(string newText)
	{
		Text = newText;
	}
}