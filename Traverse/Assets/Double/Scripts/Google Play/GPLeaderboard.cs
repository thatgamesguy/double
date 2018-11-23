using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

/// <summary>
/// Responsible for posting a score to the Google Play leaderboard and showing the leaderboard UI.
/// </summary>
public class GPLeaderboard : Singleton<GPLeaderboard>
{
	/// <summary>
	/// Posts the score if on Android platform.
	/// </summary>
	/// <param name="score">Score.</param>
	public void PostScore(int score)
    {
#if UNITY_ANDROID
        Social.ReportScore(score, GPConstants.leaderboard_double, (bool success) => {
            DebugLog.instance.ApendLog("Leaderboard score stored: " + success);
        });
#endif
    }

	/// <summary>
	/// Shows the Android leaderboard UI.
	/// </summary>
    public void ShowUI()
    {
#if UNITY_ANDROID
        DebugLog.instance.ApendLog("Attempting to open leaderboard: " + GPConstants.leaderboard_double);
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPConstants.leaderboard_double);
#endif
    }
}
