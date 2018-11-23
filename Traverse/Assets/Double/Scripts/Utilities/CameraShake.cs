using UnityEngine;
using System.Collections;

/// <summary>
/// Camera shake based on perlin noise.
/// </summary>
[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
	/// <summary>
	/// The duration of the shake.
	/// </summary>
    public float duration;

	/// <summary>
	/// The magnitude (higher = more violent shake).
	/// </summary>
    public float magnitude;

    private Camera cameraToShake;

    void Awake()
    {
        cameraToShake = GetComponent<Camera>();
    }

	/// <summary>
	/// Begin this instance.
	/// </summary>
    public void Begin()
    {
        StartCoroutine(DoShake());
    }

    private IEnumerator DoShake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = cameraToShake.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            cameraToShake.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        cameraToShake.transform.position = originalCamPos;
    }
}
