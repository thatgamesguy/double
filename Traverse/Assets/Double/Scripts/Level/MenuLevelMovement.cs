using UnityEngine;
using System.Collections;

/// <summary>
/// Responsible for scrolling the level during the main menu scene.
/// </summary>
public class MenuLevelMovement : MonoBehaviour {

    public float initialMoveSpeed = 5f;
    public float maxMoveSpeed = 12f;
    public float speedIncrease = 0.1f;

    void Update ()
    {
        Move();
        initialMoveSpeed += speedIncrease * Time.deltaTime;
        if (initialMoveSpeed > maxMoveSpeed)
        {
            initialMoveSpeed = maxMoveSpeed;
        }
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - initialMoveSpeed * Time.deltaTime);
    }
}
