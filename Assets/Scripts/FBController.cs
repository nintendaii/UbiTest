using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Facebook.Unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FBController : MonoBehaviour
{
    [SerializeField] private Button shareScreenshot;

    private void OnEnable()
    {
        shareScreenshot.onClick.AddListener(ShareScreenShot);
    }

    private void Start()
    {
        //FB.Init(OnInit);
    }

    private void OnInit()
    {
        LoginToFB();
    }

    private void LoginToFB()
    {
        FB.LogInWithPublishPermissions (
            new List<string>{"publish_to_groups"},
            LoginResult
        );
    }

    private void LoginResult(ILoginResult result)
    {
        Debug.Log("Logged to FB");
    }

    public void ShareScreenShot()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        // To avoid memory leaks
        Destroy( ss );

        new NativeShare().AddFile( filePath )
            .SetSubject( "Subject goes here" ).SetText( "Howdy Ubisoft!" ).AddTarget("com.facebook.katana")
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Share result: " + result + ", selected app: " + shareTarget  ))
            .Share();
        
    }
}
