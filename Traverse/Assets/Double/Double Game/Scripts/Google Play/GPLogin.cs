using UnityEngine;
using System.Collections;

/// <summary>
/// Activates and logs in to the Google Play platform if on Android.
/// </summary>
public class GPLogin : MonoBehaviour
{
	/// <summary>
	/// Gets a value indicating whether this <see cref="GPLogin"/> has successfully logged in to Google Play.
	/// </summary>
	/// <value><c>true</c> if logged in; otherwise, <c>false</c>.</value>
    public bool loggedIn { get; private set; }

#if UNITY_ANDROID
    void Start ()
    {
        GooglePlayGames.PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) => {
            loggedIn = success;
        
            DebugLog.instance.ApendLog("Logged in: " + success);
            if (success)
            {
                DebugLog.instance.ApendLog(Social.localUser.userName);
            }
        });
    }
#endif

}
