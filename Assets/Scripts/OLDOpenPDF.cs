using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class _OpenPDF : MonoBehaviour {
	#if !UNITY_WEBPLAYER
	public string fileName;
	private string path;
	private string savePath;

	public void ButtonClick(){
		Debug.Log ("OPEN PDF");
		StartCoroutine("OpenFile");
	}

	IEnumerator OpenFile() {


		path =Application.streamingAssetsPath + "/" + fileName;
		savePath = Application.persistentDataPath;

		WWW www = new WWW(path);
		yield return www;
		
		byte[] bytes = www.bytes;
		Debug.Log ("Done, bytes downloaded, File size : "+bytes.Length);
		
		try{
			System.IO.File.WriteAllBytes(savePath+ "/" + fileName, bytes);
		}catch(Exception ex){
			Debug.Log(ex.Message);
		}

		if(Application.platform == RuntimePlatform.Android){
			Application.OpenURL(savePath+ "/" + fileName);
		}	
		/*if(Application.platform == RuntimePlatform.IPhonePlayer){
			EtceteraBinding.showWebPage(savePath + "/" + fileName);
		}*/



		//ANDROID ONLY CODE
		/*if(Application.platform == RuntimePlatform.Android){
			path =Application.streamingAssetsPath + "/" + fileName;
			savePath = Application.persistentDataPath;
		}
		else{
			//path = "file://"+Application.streamingAssetsPath + "/2013-GL-4000.pdf";
			//savePath = "C:/Users/IBRAHI/Desktop/SaveTestUnity";
			Debug.Log("NOT MOBILE");
		}
		WWW www = new WWW(path);
		yield return www;
		
		byte[] bytes = www.bytes;
		Debug.Log ("Done, bytes downloaded, File size : "+bytes.Length);

		try{
			System.IO.File.WriteAllBytes(savePath+ "/" + fileName, bytes);
		}catch(Exception ex){
			Debug.Log(ex.Message);
		}
		Application.OpenURL(savePath+ "/" + fileName);*/

	}
	#endif
}
