using UnityEngine;
using System.Collections;

/// <summary>
/// Plays death effect when an obstacle is hit.
/// </summary>
public class PlayerInteraction : MonoBehaviour 
{
    private PlayerDeathEffect deathEffect;

    void Awake()
    {
        deathEffect = GetComponent<PlayerDeathEffect>();
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag ("Score")) 
		{
			Score.instance.RegisterScoreHit();
		} 
		else 
		{
            OnDeath();
		}
	}

    private void OnDeath()
    {
        deathEffect.Play();
        StateManager.instance.OnGameOver();
    }
}
