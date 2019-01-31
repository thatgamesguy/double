using UnityEngine;
using System.Collections;

/// <summary>
/// Listens to button press event and shows leaderboard UI.
/// </summary>
public class LeaderboardEventHandler : MonoBehaviour 
{
	/// <summary>
	/// Opens the leaderboard UI.
	/// </summary>
	public void OpenLeaderboard()
	{
		GPLeaderboard.instance.ShowUI();
	}
}
