using UnityEngine;
using System.Collections;

/// <summary>
/// Removes an object from the scene if it goes below the specified Y position.
/// </summary>
public class RemoveObjectBelowYPosition : MonoBehaviour 
{
	public float yPosition;

	void Update () 
	{
		if(transform.position.y < yPosition)
		{
			Destroy(gameObject);
		}
	}
}
