using UnityEngine;
using System.Collections;

/// <summary>
/// Non linear scale shape between two sizes.
/// </summary>
public class ScaleShapePendulum : MonoBehaviour 
{
	public Vector2 scaleOne = new Vector2(0, 0);
	public Vector2 scaleTwo = new Vector2(0, 0);

	public float speed = 1.0f;

	void Update() 
	{
		transform.localScale =  
			Vector2.Lerp (scaleOne, scaleTwo, ( Mathf.Sin( speed * Time.time ) + 1.0f ) / 2.0f);
	}
}
