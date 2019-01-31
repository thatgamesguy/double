using UnityEngine;
using System.Collections;

/// <summary>
/// Responsible for storing and retrieving current and highscore. 
/// </summary>
public class Score : Singleton<Score> 
{
	/// <summary>
	/// The score UI.
	/// </summary>
	public ScoreText scoreText;

	/// <summary>
	/// The audio player. Plays audio on score.
	/// </summary>
    [Header("Audio")]
    public AudioPlayer audioPlayer;

	/// <summary>
	/// Clip played when point scored.
	/// </summary>
    public AudioClip audioOnPoint;

	private static readonly int SCORE_HITS_REQ = 2;
	private static readonly string SCORE_KEY = "HighScore";

	private int currentScoreHit;
	private int highScore;
	private int currentScore;

	void Start()
	{
		LoadHighScore();
	}

	/// <summary>
	/// Invoked when player finishes section.
	/// </summary>
	public void RegisterScoreHit()
	{
		currentScoreHit++;

		if(currentScoreHit >= SCORE_HITS_REQ)
		{
            audioPlayer.PlayOneShot(audioOnPoint);
			IncreaseScore();
			currentScoreHit = 0;
		}
	}

	/// <summary>
	/// Gets the high score.
	/// </summary>
	/// <returns>The high score.</returns>
	public int GetHighScore()
	{
		return highScore;
	}

	/// <summary>
	/// Gets the current score.
	/// </summary>
	/// <returns>The current score.</returns>
	public int GetScore()
	{
		return currentScore;
	}

	/// <summary>
	/// Stores high score on game over.
	/// </summary>
    public void OnGameOver()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }
    }

	private void IncreaseScore()
	{
		currentScore++;

		scoreText.UpdateScore(currentScore);
	}

	private void LoadHighScore()
	{
		highScore = PlayerPrefs.GetInt(SCORE_KEY, 0);
	}

	private void SaveHighScore()
	{
		PlayerPrefs.SetInt(SCORE_KEY, highScore);
		GPLeaderboard.instance.PostScore(highScore);
	}
}
