using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Responsible for updating score UI.
/// </summary>
[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour 
{
	private Text text;

	void Awake()
	{
		text = GetComponent<Text>();
	}

	/// <summary>
	/// Converts to string and displays.
	/// </summary>
	/// <param name="score">Score.</param>
	public void UpdateScore(int score)
	{
		text.text = score.ToString("d2");
	}
}
