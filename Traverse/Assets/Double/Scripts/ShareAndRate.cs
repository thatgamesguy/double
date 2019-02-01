using UnityEngine;
using System.Collections;

/// <summary>
/// Provides functionality to access Android share features and open links to the apps page on ituns and the google play store.
/// </summary>
public class ShareAndRate : MonoBehaviour
{
    /// <summary>
    /// Opens a URL to googleplay store or itunes store.
    /// </summary>
    public void Rate()
    {
        print("Place link to the game in the store here");
        Application.OpenURL("https://assetstore.unity.com/packages/templates/tutorials/double-82077");

    }

    /// <summary>
    /// If on android: loads inbuilt share features.
    /// </summary>
    public void Share()
	{
        print("Place share code here");
    }

}
