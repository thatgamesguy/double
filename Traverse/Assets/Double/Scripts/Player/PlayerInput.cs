using UnityEngine;
using System.Collections;

/// <summary>
/// Updates player position (left and right).
/// </summary>
public class PlayerInput : MonoBehaviour 
{
	/// <summary>
	/// The state manager. Informs state manager to start game when player has placed fingers on both sides of screen.
	/// </summary>
    public StateManager stateManager;

	/// <summary>
	/// Starts level movement when player has placed fingers on both sides of screen.
	/// </summary>
	public LevelMovement levelMovement;

	/// <summary>
	/// Object responsible for updating plays position.
	/// </summary>
	public PlayerPlacement[] playerPlacements;

	/// <summary>
	/// The audio player to start BGM.
	/// </summary>
    public BackgroundAudioPlayer audioPlayer;

	private static readonly int NUM_OF_INPUT = 2;
	private static readonly float Y_OFFSET = 1.7f;

	private bool shouldUpdate;
    private bool setAudioToPlay;

	// Use this for initialization
	void Start () 
	{
		shouldUpdate = true;

		if(playerPlacements.Length != NUM_OF_INPUT)
		{
			Debug.LogError("Incorrect number of players");
		}

        PickupPlayers();
        levelMovement.StopMovement();
    }

	/// <summary>
	/// Stops listening for player input.
	/// </summary>
    public void StopPlayerInput()
	{
		PickupPlayers();
		levelMovement.StopMovement();
		shouldUpdate = false;
	}

	void Update () 
	{
		
		if(!shouldUpdate)
		{
			return;
		}
		
		if(!HasRequiredNumberOfTouches())
		{
			//PickupPlayers();

			//levelMovement.StopMovement();

			return;
		}

		Vector2?[] positions = new Vector2?[NUM_OF_INPUT];

		for (var i = 0; i < NUM_OF_INPUT; i++) 
		{
			var touch = Input.GetTouch(i);

			Vector2 worldPosition = ToWorldPosition(touch.position) + (Vector2.up * Y_OFFSET);

			if(worldPosition.x < 0f)
			{
				positions [0] = worldPosition;
			}
			else if(worldPosition.x > 0f)
			{
				positions [1] = worldPosition;
			}

		}

		if(PlayerHasCorrectPlacement(positions))
		{
			levelMovement.StartMovement();

			PlacePlayers(positions);

            if(!setAudioToPlay)
            {
                stateManager.OnGameStart();
                setAudioToPlay = true;
                audioPlayer.Play();
            }
		}
	
	}

	private bool HasRequiredNumberOfTouches()
	{
		return Input.touchCount >= NUM_OF_INPUT;
	}

	private void PickupPlayers()
	{
		foreach(var player in playerPlacements)
		{
			player.PickUp();
		}
	}

	private float ToScreenPositionNormalized(Vector2 screenPosition)
	{
		return screenPosition.x / Screen.height;
	}

	private Vector2 ToWorldPosition(Vector2 screenPosition)
	{
		return Camera.main.ScreenToWorldPoint(screenPosition);
	}

	private bool PlayerHasCorrectPlacement(Vector2?[] positions)
	{	
		foreach(var position in positions)
		{
			if(!position.HasValue)
			{
				return false;
			}
		}

		return true;
	}

	private void PlacePlayers(Vector2?[] positions)
	{
		for(int i = 0; i < positions.Length; i++)
		{
			playerPlacements[i].Place(positions[i].Value);
		}
	}
		
}
