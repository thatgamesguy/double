using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Updates the games state.
/// </summary>
public class StateManager : Singleton<StateManager> 
{

	public PlayerInput playerInput;

    public GameObject instructionsUI;

    [Header("Game Over UI")]
	public GameObject inGameUI;
	public GameObject gameOverUI;

    [Header("Text")]
	public ScoreText scoreText;
	public ScoreText highScoreText;

    public CameraShake shake;

    [Header("Game Oover Delay")]
    public float secsDelayOnGameOver = 0.5f;

    [Header("Audio")]
    public AudioClip gameOverAudio;
    public AudioClip audioOnDeath;
    public AudioClip audioOnRestart;
    public AudioPlayer audioPlayer;

	void Start()
	{
		gameOverUI.SetActive(false);
	}

	/// <summary>
	/// Disables the instructions UI.
	/// </summary>
    public void OnGameStart()
    {
        instructionsUI.SetActive(false);
    }

	/// <summary>
	/// Shows game over UI, updates high score, and stops player input.
	/// </summary>
	public void OnGameOver()
	{
        StartCoroutine(DoGameOver());
	}

    private IEnumerator DoGameOver()
    {
        audioPlayer.PlayOneShot(audioOnDeath);
        shake.Begin();

        yield return new WaitForSeconds(secsDelayOnGameOver);

        audioPlayer.Play(gameOverAudio);

        Score.instance.OnGameOver();

        inGameUI.SetActive(false);
        playerInput.StopPlayerInput();

        scoreText.UpdateScore(Score.instance.GetScore());
        highScoreText.UpdateScore(Score.instance.GetHighScore());

        gameOverUI.SetActive(true);
    }

	/// <summary>
	/// Loads the game scene.
	/// </summary>
	public void OnRestart()
	{
        audioPlayer.PlayOneShot(audioOnRestart);

        SceneManager.LoadScene(1);
	}
}
