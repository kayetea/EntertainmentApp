using UnityEngine;
using System;
using System.IO;
using System.Collections;
using IndieYP;

public class OpenPDF : MonoBehaviour 
{
	public string namePDF;
	private string streamingPdf = "";
	private string localHTML = "";



	void Start()
	{
		//BUILD PDF PATH FROM STREAMING ASSETS 
		streamingPdf = PDFReader.AppDataPath + "/" + namePDF + ".pdf";
		//localHTML = PDFReader.AppDataPath + "/" +"main.html";
	}

	public void ExternalOpenPDF()
	{
		#if UNITY_ANDROID
			StartCoroutine(PDFReader.OpenDocLocal(namePDF));
		#endif
		#if UNITY_IPHONE
			PDFReader.OpenDocInMenu(streamingPdf, true );
		#endif

		Debug.Log("OPEN PDF");
	}

}