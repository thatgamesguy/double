using UnityEngine;
using System.Collections;

/// <summary>
/// The position of the level section (left or right).
/// </summary>
public enum Position
{
	Left,
	Right
}

public class ObjectColour : MonoBehaviour 
{
	//private static readonly float MIN_RANGE = -4.4f;
	//private static readonly float MAX_RANGE = -4.4f;

	//private static readonly float NEW_MIN = 0f;
	//private static readonly float NEW_MAX = 1f;

	private SpriteRenderer spriteRenderer;

	void Awake()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Updates the colour of the object based on its position on screen.
	/// </summary>
	/// <param name="leftColour">Colour for left level section.</param>
	/// <param name="rightColour">Colour for right level section..</param>
	/// <param name="position">Position of level section.</param>
	public void UpdateColour(Color leftColour, Color rightColour, Position position)
	{
        /*float minRange = (position == Position.Left) ? -8.8f : -4.4f;
		float maxRange = (position == Position.Left) ? 4.4f : 8.8f;

		float interp = (((transform.position.x - minRange) * (NEW_MAX - NEW_MIN)) / (maxRange - minRange)) + NEW_MIN;*/

		Color color = (position == Position.Left) ? leftColour : rightColour;

        spriteRenderer.color = color; // Color.Lerp(from, to, interp);
	}

}
