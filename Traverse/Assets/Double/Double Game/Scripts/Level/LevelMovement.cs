using UnityEngine;
using System.Collections;

/// <summary>
/// Responsible for scrolling the level.
/// </summary>
public class LevelMovement : MonoBehaviour
{
	/// <summary>
	/// The initial move speed.
	/// </summary>
	public float initialMoveSpeed = 5f;

	/// <summary>
	/// The max move speed.
	/// </summary>
    public float maxMoveSpeed = 12f;

	/// <summary>
	/// The speed increase each second.
	/// </summary>
    public float speedIncrease = 0.1f;

	private bool shouldMove;

	void Start () 
	{
		StartMovement();
	}

	void Update () 
	{
		if(shouldMove)
		{
			Move();
            initialMoveSpeed += speedIncrease * Time.deltaTime;
            if(initialMoveSpeed > maxMoveSpeed)
            {
                DebugLog.instance.ApendLog("Max speed");
                initialMoveSpeed = maxMoveSpeed;
            }

        }
		
	}

	/// <summary>
	/// Starts the level movement.
	/// </summary>
	public void StartMovement()
	{
		shouldMove = true;
	}

	/// <summary>
	/// Stops the level movement.
	/// </summary>
	public void StopMovement()
	{
		shouldMove = false;
	}

	private void Move()
	{
		transform.position = new Vector2(transform.position.x, transform.position.y - initialMoveSpeed * Time.deltaTime);
	}

}
