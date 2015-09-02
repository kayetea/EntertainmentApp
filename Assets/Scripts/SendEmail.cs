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
		string subject = MyEscapeURL("ETC's Commercial Simulation Products");
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
		bodyText = "Dear " + clientName.GetComponent<Text>().text + ", \n \nThank you for your time and interest today in ETC's Commercial Simulation Products. " +
			"As we discussed, listed below is more information on the products and unique environment experiences we offer. " +
			"Also below is my contact information should you have further questions or would like to request a formal quote or proposal." +
			"\n\nFor general information on the products and services we provide, please check out our overview trifold here - http://www.etcusa.com/thrills/Simulated-Experiences.pdf";

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

		//check if any products were selected
		if(productList.Count > 0 )
		{
			bodyText = bodyText + "\n\nHere is more information on your selected products -- please follow the links below to access the media.";
		}


		//turn array into body text
		foreach(string product in productList)
		{
			string productText = " ";
			switch (product)
			{
			case "ATFS400":
				productText = "ATFS-400 Centrifuge - http://www.etcusa.com/thrills/ATFS-400.pdf";
				break;
			case "GAT":
				productText = "GAT (General Aviation Trainer) - http://www.etcusa.com/thrills/GAT.pdf";
				break;
			case "GL2000":
				productText = "GL-2000 Gyrolab - http://www.etcusa.com/thrills/GL2000.pdf";
				break;
			case "GL4000":
				productText = "GL-4000 Gyrolab - http://www.etcusa.com/thrills/GL4000.pdf";
				break;
			case "GL6000":
				productText = "GL-2000 Gyrolab - http://www.etcusa.com/thrills/GL6000.pdf";
				break;
			case "IPT2":
				productText = "IPT2 (Integrated Physiological Trainer) - http://www.etcusa.com/thrills/IPTII.pdf";
				break;
			case "IPT3":
				productText = "For more information on our IPT3, please stay in touch.";
				break;
			case "XForce":
				productText = "XForce Multi-arm Centrifuge - http://www.etcusa.com/thrills/XForce.pdf";
				break;
			case "XSpeed":
				productText = "XSpeed Motion Base - http://www.etcusa.com/thrills/XSpeed.pdf";
				break;
			case "XVector":
				productText = "XVector Motion Base - http://www.etcusa.com/thrills/XVector.pdf";
				break;
			case "NonMotion":
				productText = "For more information on our NonMotion products, please stay in touch.";
				break;
			}


			bodyText = bodyText + "\n" + productText; 
		}


		bodyText = bodyText + "\n \nThank you. \n \nBrienna Henwood \nBHenwood@etcusa.com \n+1-215-355-9100 x 1504 \nhttp://www.etcusa.com \nhttp://www.nastarcenter.com";

	}

}