using UnityEngine;
using System.Collections;

/// <summary>
/// Responsible for playing background audio. Attached to AudioSource.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class BackgroundAudioPlayer : MonoBehaviour
{
	/// <summary>
	/// Random clip is selected to play.
	/// </summary>
    public AudioClip[] backgroundAudioClips;

    public bool playOnStart = false;

    private AudioSource audioSource;

	void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.clip = backgroundAudioClips[Random.Range(0, backgroundAudioClips.Length)];

        if(playOnStart)
        {
            Play();
        }
    }

	/// <summary>
	/// Plays the clip attached to audio source.
	/// </summary>
    public void Play()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
	
}
