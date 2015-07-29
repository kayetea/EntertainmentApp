using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour {

	private GameObject currentScreen;
	public GameObject newScreen;
	private GameObject prevScreen;

	private string currentString;
	private string prevString;

	private Vector2 offScreen = new Vector2(2140, 0);
	private Vector2 origin = new Vector2(0,0);

	//Environment Variables
	private Texture background;
	private string title;
	private string subtitle;
	private string infoText;
	private GameObject scrollImage;

	//Product Variables
	private GameObject mediaPanel;
	
	[Header("Ocean")]
	public Texture oceanbg;
	public GameObject oceanScroll;
	[Header("Land")]
	public Texture landbg;
	public GameObject landScroll;
	[Header("Aviation")]
	public Texture aviationbg;
	public GameObject aviationScroll;
	[Header("Space")]
	public Texture spacebg;
	public GameObject spaceScroll;
	[Header("Beyond")]
	public Texture beyondbg;
	public GameObject beyondScroll;

	[Header("Product Media Panels")]
	public GameObject atfs400Media;	
	public GameObject gatMedia;
	public GameObject gl2000Media;
	public GameObject gl4000Media;
	public GameObject gl6000Media;
	public GameObject ipt2Media;
	public GameObject ipt3Media;
	public GameObject xforceMedia;
	public GameObject xspeedMedia;
	public GameObject xvectorMedia;

	void Start () {
		currentScreen = GameObject.Find("HomePanel");
	}

	public void ChangePrevSceneOnClick (){
		if(prevString != null)
		{
			ChangeSceneOnClick(prevString);
		}
	}
	
	public void ChangeSceneOnClick (string myString){
		string[] stringArray = myString.Split(':');
		string panelName = stringArray[0];
		string exactPage = stringArray[1];

		newScreen = GameObject.Find(panelName);

		//move previous screen off screen
		currentScreen.GetComponent<RectTransform>().anchoredPosition = offScreen;

		//move new screen to origin and assign as current
		newScreen.GetComponent<RectTransform>().anchoredPosition = origin;
		prevScreen = currentScreen;
		currentScreen = newScreen;

		//MAKE SMARTER AND KNOW WHAT PAGE IT IS COMING FROM
		//remove any scrollstacks & media panels
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().RemoveStacks();
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().enabled = false;
		foreach (Transform child in transform.Find("ProductPanel/Media"))
		{
			GameObject.Destroy(child.gameObject);
		}

		//customize new screen
		if(panelName == "EnvironmentPanel")
		{
			SetEnvironmentScreen(exactPage);
		}
		if(panelName =="ProductPanel")
		{
			SetProductScreen(exactPage);
		}
	}

	private void SetEnvironmentScreen(string page){
		Debug.Log (page);

		switch (page)
		{
		case "Ocean":
			background = oceanbg;
			title = "OCEAN";
			subtitle = "SUBMARINE - BOATS";
			infoText = "Please provide a little explaination of what types of experiences we can provide to create an ocean experience.";
			scrollImage = oceanScroll;
			break;
		case "Land":
			background = landbg;
			title = "LAND";
			subtitle = "SUBMARINE - BOATS";
			infoText = "Please provide a little explaination of what types of experiences we can provide to create an ocean experience.";
			scrollImage = landScroll;
			break;
		case "Aviation":
			background = aviationbg;
			title = "AVIATION";
			subtitle = "JET - AIRCRAFT - HELICOPTER";
			infoText = "Please provide a little explaination of what types of experiences we can provide to create an ocean experience.";
			scrollImage = aviationScroll;
			break;
		case "Space":
			background = spacebg;
			title = "SPACE";
			subtitle = "SUBORBITAL - ORBITAL";
			infoText = "Please provide a little explaination of what types of experiences we can provide to create an ocean experience.";
			scrollImage = spaceScroll;
			break;
		case "Beyond":
			background = beyondbg;
			title = "BEYOND";
			subtitle = "MARS - ASTEROIDS - DEEP SPACE";
			infoText = "Please provide a little explaination of what types of experiences we can provide to create an ocean experience.";
			scrollImage = beyondScroll;
			break;
		}

		//set background
		transform.Find("EnvironmentPanel/Background").GetComponent<RawImage>().texture = background;
		//set title panel (title, subtitle, text block)
		transform.Find("EnvironmentPanel/Title Panel/Title").GetComponent<Text>().text = title;
		transform.Find("EnvironmentPanel/Title Panel/Subtitle").GetComponent<Text>().text = subtitle;
		transform.Find("EnvironmentPanel/Title Panel/Text").GetComponent<Text>().text = infoText;
		//enable & assign scroll panel + prefab height
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().enabled = true;
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().scrollImagePrefab = scrollImage;
	}

	private void SetProductScreen(string page){
		switch (page)
		{
		case "ATFS400":
			//background = gl4000bg;
			title = "ATFS-4000";
			subtitle = "CENTRIFUGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = atfs400Media;
			break;
		case "GAT":
			//background = gl4000bg;
			title = "GAT";
			subtitle = "SUBTITLE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = gatMedia;
			break;
		case "GL2000":
			//background = gl2000bg;
			title = "GL-2000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = gl2000Media;
			break;
		case "GL4000":
			//background = gl4000bg;
			title = "GL-4000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = gl4000Media;
			break;
		case "GL6000":
			//background = gl4000bg;
			title = "GL-6000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = gl6000Media;
			break;
		case "IPT2":
			//background = gl4000bg;
			title = "IPT2";
			subtitle = "INTEGRATED PHYSIOLOGICAL TRAINER";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = ipt2Media;
			break;
		case "IPT3":
			//background = gl4000bg;
			title = "IPT3";
			subtitle = "SUBTITLE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = ipt3Media;
			break;
		case "XForce":
			//background = gl4000bg;
			title = "XFORCE";
			subtitle = "MULTI-ARM CENTRIFUGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = xforceMedia;
			break;
		case "XSpeed":
			//background = gl4000bg;
			title = "XSPEED";
			subtitle = "SUBTITLE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = xspeedMedia;
			break;
		case "XVector":
			//background = gl4000bg;
			title = "XVECTOR";
			subtitle = "MONSTER ROLL CAGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = xvectorMedia;
			break;
		}

		//set background
		//set title panel (title, subtitle, text block)
		transform.Find("ProductPanel/Title Panel/Title").GetComponent<Text>().text = title;
		transform.Find("ProductPanel/Title Panel/Subtitle").GetComponent<Text>().text = subtitle;
		transform.Find("ProductPanel/Title Panel/Text").GetComponent<Text>().text = infoText;
		//photo panels
		GameObject myMediaPanel = Instantiate(mediaPanel);
		myMediaPanel.transform.SetParent(transform.Find("ProductPanel/Media"), false);
		//3d object
	}
}
