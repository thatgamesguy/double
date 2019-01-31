using UnityEngine;
using System.Collections;

/// <summary>
/// Provides functionality to access Android share features and open links to the apps page on ituns and the google play store.
/// </summary>
public class ShareAndRate : MonoBehaviour
{
    /// <summary>
    /// Edit these with your app id's.
    /// </summary>
#if UNITY_ANDROID
    private static readonly string ANDROID_APP_ID = "com.appID";
    private static readonly string SUBJECT = "";
    private static readonly string BODY = "Can you beat my score in double?";
#elif UNITY_IPHONE
    private static readonly string IOS_APP_ID = "000000000";
#endif

    /// <summary>
    /// Opens a URL to googleplay store or itunes store.
    /// </summary>
    public void Rate()
    {
#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + ANDROID_APP_ID);
#elif UNITY_IPHONE
		Application.OpenURL("itms-apps://itunes.apple.com/app/id" + IOS_APP_ID);
#endif


    }

	/// <summary>
	/// If on android: loads inbuilt share features.
	/// </summary>
    public void Share()
	{
#if UNITY_ANDROID
        StartCoroutine(ShareAndroidText());
#endif
    }

    private IEnumerator ShareAndroidText()
	{
		yield return new WaitForEndOfFrame();
		//execute the below lines if being run on a Android device
#if UNITY_ANDROID
		//Reference of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		//Reference of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		//call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		//set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		//add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), SUBJECT);
		//intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TITLE"), "Text Sharing ");
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), BODY);
		//get the current activity
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		//start the activity by sending the intent data
		AndroidJavaObject jChooser = intentClass.CallStatic<AndroidJavaObject>("createChooser", intentObject, "Share Via");
		currentActivity.Call("startActivity", jChooser);
#endif
	}

}
