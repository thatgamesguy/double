using UnityEngine;

/// <summary>
/// Spawns particle effect on player death.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerDeathEffect : MonoBehaviour
{
	/// <summary>
	/// The death effect prefab.
	/// </summary>
    public GameObject deathEffectPrefab;

    private PlayerPlacement playerPlacement;

    void Awake()
    {
        playerPlacement = GetComponent<PlayerPlacement>();
    }

	/// <summary>
	/// Spawns prefab.
	/// </summary>
    public void Play()
    {
        playerPlacement.RemoveFromGame();
        Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
    }
}
