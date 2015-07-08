using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.InteropServices;

namespace IndieYP
{

public class PDFReader : MonoBehaviour 
{
	public const string STATUS_COMPLETE = "OK";
	public enum Anchor
		{
			Default,
			Bottom
		}

	[DllImport("__Internal")]
	private static extern void OpenDocumentInMenu (string docPath, bool onlyThirdPartyApp, Anchor anchor);
	[DllImport("__Internal")]
	private static extern void OpenDocumentInWebViewLocal (string docPath, string docTitle);
	[DllImport("__Internal")]
	private static extern void OpenDocumentInWebViewLocalWithCallback(string docPath, string docTitle, string goName, string callbackMethod);
	[DllImport("__Internal")]
	private static extern void OpenDocumentInWebViewRemote (string docTitle, string docRemoteURL);
	[DllImport("__Internal")]
	private static extern void OpenDocumentInWebViewRemoteWithCallback (string docTitle, string docRemoteURL, string goName, string callbackMethod);
	[DllImport("__Internal")]
	private static extern void OpenDocumentCG (string docPath, int from, int to, string rect);
	[DllImport("__Internal")]
	private static extern void OpenHTML (string docPath, string navbarTitle);

#if UNITY_IPHONE
	public static void OpenDocInMenu (string docPath, bool onlyThirdPartyApp, Anchor anchor = Anchor.Bottom)
	{
		OpenDocumentInMenu (docPath, onlyThirdPartyApp, anchor);
	}

	public static void OpenDocInWebViewLocal (string docPath, string docTitle)
	{
		OpenDocumentInWebViewLocal (docPath, docTitle);
	}

	public static void OpenDocInWebViewLocal (string docPath, string docTitle, string goName, string callbackMethod)
	{
		OpenDocumentInWebViewLocalWithCallback (docPath, docTitle, goName, callbackMethod);
	}

	public static void OpenDocInWebViewRemote (string docTitle, string docRemoteURL)
	{
		OpenDocumentInWebViewRemote (docTitle, docRemoteURL);
	}

	public static void OpenDocInWebViewRemote (string docTitle, string docRemoteURL,  string goName, string callbackMethod)
	{
		OpenDocumentInWebViewRemoteWithCallback (docTitle, docRemoteURL, goName, callbackMethod);
	}

	public static void OpenDocCG (string docPath, int from = -7, int to = 0, string rect = "")
	{
		if(string.IsNullOrEmpty(rect))
			rect = "0,0," + Screen.width.ToString() + "," + Screen.height.ToString();
		OpenDocumentCG (docPath, from, to, rect);
	}
	public static void OpenHTMLLocal (string docPath, string navbarTitle)
	{
			OpenHTML(docPath, navbarTitle);
	}

#endif

#if UNITY_ANDROID
	private static AndroidJavaClass pdfJavaClass;
	private static AndroidJavaObject activity;
	private static void InitJava()
	{
		if(pdfJavaClass == null)
		{
			AndroidJavaClass unityJC = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			activity = unityJC.GetStatic<AndroidJavaObject>("currentActivity");
			pdfJavaClass = new AndroidJavaClass("com.SlavaObninsk.pdfreader.Logic");
		}
	}

	public static void OpenDocRemote (string docRemoteURL)
	{
		InitJava();
		pdfJavaClass.CallStatic("OpenDocRemote", activity, docRemoteURL);
	}
	public static void OpenDocRemote (string docRemoteURL, bool useGoogleDocs)
	{
		if(useGoogleDocs)
		{
			InitJava();
			pdfJavaClass.CallStatic("OpenInGoogleDocs", activity, docRemoteURL);
		}
		else
		{
			OpenDocRemote(docRemoteURL);
		}
	}


	public static IEnumerator OpenDocLocal (string pdfName)
	{
		string fromPath = Application.streamingAssetsPath +"/";
		string toPath =  Application.persistentDataPath + "/";
		string file = pdfName + ".pdf";
		WWW www = new WWW ( fromPath + file);
		yield return www;

		string tempPath =  toPath + file;

		if (!File.Exists(tempPath))
			File.WriteAllBytes(tempPath, www.bytes);
		
		PDFReader.OpenDocLocalNative(tempPath);
	}

	private static void OpenDocLocalNative (string docLocalURL)
	{
		InitJava();
		pdfJavaClass.CallStatic("OpenDocLocal", activity, docLocalURL);
	}


#endif
	
#region IO METHODS

	/// <summary>
	/// Gets the app streaming assets data path.
	/// </summary>
	/// <value>The app data path.</value>
	public static Uri AppDataPath
	{
		get 
		{
			UriBuilder uriBuilder = new UriBuilder();      
			uriBuilder.Scheme = "file";
			uriBuilder.Path = System.IO.Path.Combine(appDataPath, "Raw");
			return uriBuilder.Uri;
		}
	}

	private static string appDataPath
	{
		get 
		{               
			return Application.dataPath;
		}
	}

#endregion
}

}