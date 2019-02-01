using UnityEngine;
using System.Collections;

/// <summary>
/// Responsible for updating child objects colour.
/// </summary>
public class LevelColour : MonoBehaviour 
{
	private ObjectColour[] childColours;

	void Awake()
	{
		childColours = GetComponentsInChildren<ObjectColour>();
	}

	/// <summary>
	/// Updates the colours of child objects.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	/// <param name="position">Position.</param>
	public void UpdateColours(Color from, Color to, Position position)
	{
		foreach(var colour in childColours)
		{
			colour.UpdateColour(from, to, position);
		}
	}
}
