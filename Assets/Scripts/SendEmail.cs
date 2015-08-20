using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class SendEmail : MonoBehaviour
{
	public GameObject emailAddress;
	public GameObject buttonCollection;
	public GameObject clientName;
	private string bodyText;
	private List<string> productList = new List<string> ();

	
	public void EmailUs () 
	{

		//email Id to send the mail to
		string email = emailAddress.GetComponent<Text>().text;
		//subject of the mail
		string subject = MyEscapeURL("ETC Entertainment Products");
		//body of the mail which consists of Device Model and its Operating System
		BuildBody();
		string body = MyEscapeURL(bodyText);
		//Open the Default Mail App
		Application.OpenURL ("mailto:" + email + "?subject=" + subject + "&body=" + body);


	}  
	
	string MyEscapeURL (string url) 
	{
		return WWW.EscapeURL(url).Replace("+","%20");
	}

	private void BuildBody(){
		bodyText = "Dear " + clientName.GetComponent<Text>().text + ", \n \nThank you for your time and interest today in ETC Commercial Simulation Products. " +
			"As we discussed, listed below is more information on the products and unique environment experiences we offer. " +
			"Also below is my contact information should you have further questions or would like to request a formal quote or proposal." +
			"\nHere is literature on the specific products and experiences we discussed. Please follow the links below to access the media.";

		foreach(Transform child in transform)
		{
			if(!child.GetComponent<Scrollbar>())//make sure not checking scrollbar element
			{
				if(child.GetComponent<Toggle>().isOn)
				{
					string name = child.name;
					productList.Add(name);
				}
			}
		}
		//turn array into body text
		foreach(string product in productList)
		{
			bodyText = bodyText + "\n" + product; 
		}


		bodyText = bodyText + "\n \nThank you. \n \nBrienna Henwood \nBHenwood@etcusa.com \n+1-215-355-9100 x 1504 \nhttp://www.etcusa.com \nhttp://www.nastarcenter.com";

	}

}