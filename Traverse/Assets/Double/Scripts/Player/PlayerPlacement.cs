using UnityEngine;
using System.Collections;

/// <summary>
/// Player placement. Responsible for placing the player in the specified position.
/// </summary>
public class PlayerPlacement : MonoBehaviour 
{
	private Collider2D playerCollider;
	private SpriteRenderer spriteRenderer;

    private bool disabledForLife = false;

	void Awake()
	{
		playerCollider = GetComponent<Collider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Start()
	{
		PickUp();
	}

	/// <summary>
	/// Places the player at the specified position.
	/// </summary>
	/// <param name="position">Position.</param>
	public void Place(Vector2 position)
	{
        if (!disabledForLife)
        {
            transform.position = position;
            playerCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
	}

	/// <summary>
	/// Disables players collider and renderer.
	/// </summary>
	public void PickUp()
	{
		playerCollider.enabled = false;
		spriteRenderer.enabled = false;
	}

	/// <summary>
	/// Disables players collider and renderer and stops player from being placed again.
	/// </summary>
    public void RemoveFromGame()
    {
        disabledForLife = true;
        PickUp();
    }
}
