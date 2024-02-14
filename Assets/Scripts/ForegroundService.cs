using UnityEngine;

public class ForegroundService : AndroidJavaProxy
{
    public ForegroundService() : base("com.unity3d.player.UnityPlayer$Activity") { }

    public void StartService()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass serviceClass = new AndroidJavaClass("com.DefaultCompany.ML.ForegroundService");
        activity.Call("startService", serviceClass);
    }

    public void StopService()
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        AndroidJavaClass serviceClass = new AndroidJavaClass("com.DefaultCompany.ML.ForegroundService");
        activity.Call("stopService", serviceClass);
    }
}
