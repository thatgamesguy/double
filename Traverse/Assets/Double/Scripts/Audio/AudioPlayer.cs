using UnityEngine;

/// <summary>
/// Responsible for playing audio clips.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

	/// <summary>
	/// Stops any playing audio and plays the specified clip.
	/// </summary>
	/// <param name="clip">Clip.</param>
	public void Play(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

	/// <summary>
	/// Plays the clip once.
	/// </summary>
	/// <param name="clip">Clip.</param>
    public void PlayOneShot(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
