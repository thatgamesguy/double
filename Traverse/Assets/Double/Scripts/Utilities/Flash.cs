using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Flashes an image on screen.
/// </summary>
public class Flash : MonoBehaviour
{
	/// <summary>
	/// The second delay between flashes.
	/// </summary>
    public float secDelayBetweenFlashes = 1f;

	/// <summary>
	/// The seconds delay to re enable image once disabled.
	/// </summary>
    public float secDelayToReEnable = 0.1f;

    private float currentDelay;

    private Image image;

	void Awake()
    {
        image = GetComponent<Image>();
	}

	void Update ()
    {
        if (image.enabled)
        {
            currentDelay += Time.deltaTime;

            if (currentDelay >= secDelayBetweenFlashes)
            {
                currentDelay = 0f;
                image.enabled = false;
            }
        }
        else
        {
            currentDelay += Time.deltaTime;

            if(currentDelay >= secDelayToReEnable)
            {
                currentDelay = 0f;
                image.enabled = true;
            }
        }
	
	}
}
