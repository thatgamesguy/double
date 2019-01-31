using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Responsible for updating Main Menu and loading game scene.
/// </summary>
public class MainMenu : MonoBehaviour
{
    public ScoreText highScoreText;

    [Header("Audio")]
    public AudioPlayer audioPlayer;
    public AudioClip uiSelectAudio;

    void Start()
    {
        highScoreText.UpdateScore(Score.instance.GetHighScore());
    }

	/// <summary>
	/// Loads game scene.
	/// </summary>
    public void PlayGame()
    {
        audioPlayer.PlayOneShot(uiSelectAudio);
        SceneManager.LoadScene(1);
    }
	
}
