using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Displays initial instructions to player.
/// </summary>
public class Instructions : MonoBehaviour
{
    public Text leftText;
    public Image leftImage;

    public Text rightText;
    public Image rightImage;
    
	/// <summary>
	/// Sets the colours to fit the level section colour scheme.
	/// </summary>
	/// <param name="levelColour">Level colour.</param>
    public void SetColours(LevelColours levelColour)
    {
        leftText.color = levelColour.fromColour;
        leftImage.color = levelColour.fromColour;

        rightText.color = levelColour.toColour;
        rightImage.color = levelColour.toColour;
    }
}
