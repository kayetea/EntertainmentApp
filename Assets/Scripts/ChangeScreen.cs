using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeScreen : MonoBehaviour {

	private GameObject currentScreen;
	public GameObject newScreen;
    public GoogleAnalyticsV4 googleAnalytics;

	private string currentString;
	private List<string> prevStrings = new List<string> ();

	private Vector2 offScreen = new Vector2(2140, 0);
	private Vector2 origin = new Vector2(0,0);

	//Environment Variables
	private Texture2D background;
	private string title;
	private string subtitle;
	private string infoText;
	private GameObject scrollImage;
	private GameObject photoPanel;
	public GameObject gForce;

	//Product Variables
	private GameObject mediaPanel;

	void Start () {
		currentScreen = GameObject.Find("HomePanel");
		prevStrings.Add ("HomePanel:null");

        googleAnalytics.StartSession();
        googleAnalytics.LogScreen("Main Menu");
	}



	public void ChangePrevSceneOnClick (){
		//get how many 
		int pageCount = prevStrings.Count;

		//set previous page
		string prevMyString = prevStrings[pageCount-2];

		//remove last two items (current page and page you're about to visit), don't delete list if on last page
		if(pageCount > 2){
			prevStrings.RemoveRange(pageCount-2, 2);
		}
		else if(pageCount == 2)
		{
			prevStrings.Remove(prevStrings[pageCount-1]);
		}

		//open previous page
		ChangeSceneOnClick(prevMyString);
	}
	
	public void ChangeSceneOnClick (string myString){
		//~~~~~~~~~~WAIT FOR IT TO FADE OUT BEFORE PROCEEDING~~~~~~~~~~
		//fade between pages
		GameObject.Find("Fade").GetComponent<Animator>().Play("SceneFadeOut");

		StartCoroutine(DelayMoveAndSet(myString));

		//~~~~~~~~~~ADD STRING TO LIST AND MOVE AND CREATE PAGES~~~~~~~~~~
		prevStrings.Add(myString);

        
    }

	IEnumerator DelayMoveAndSet(string myString){
		yield return new WaitForSeconds(1f);
		MoveAndSet(myString);
	}

	private void MoveAndSet(string myString){
		//split string into two variables
		string[] stringArray = myString.Split(':');
		string panelName = stringArray[0];
		string exactPage = stringArray[1];
		
		newScreen = GameObject.Find(panelName);
		
		//move previous screen off screen
		currentScreen.GetComponent<RectTransform>().anchoredPosition = offScreen;
		
		//move new screen to origin and assign as current
		newScreen.GetComponent<RectTransform>().anchoredPosition = origin;
		currentScreen = newScreen;

        googleAnalytics.LogScreen(panelName);

        //~~~~~~~~~~CLEAN UP ANY PREVIOUS SCENE LEFTOVER CONTENT~~~~~~~~~~

        //remove any scrollstacks using a function in the LoopImageStack script
        transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().RemoveStacks();
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().enabled = false;
		gForce.SetActive(true);
		Resources.UnloadUnusedAssets ();
		
		//if any Media panels, remove them!
		foreach (Transform child in transform.Find("ProductPanel/Media"))
		{
			GameObject.Destroy(child.gameObject);
		}
		
		//~~~~~~~~~~CUSTOMIZE SCREEN TO SPECIFIC PAGE~~~~~~~~~~
		
		//customize new screen
		if(panelName == "EnvironmentPanel")
		{
			SetEnvironmentScreen(exactPage);
		}
		if(panelName =="ProductPanel")
		{
			SetProductScreen(exactPage);
		}
		if(panelName =="MailPanel")
		{
			background = Resources.Load("BgImages/neutral-background") as Texture2D;
			//set background
			transform.Find("BackgroundCamera/BackgroundImage").GetComponent<SpriteRenderer>().sprite = Sprite.Create (background, new Rect(0, 0, 2048, 1536), new Vector2(0.5f,0.5f));
		}
		if(panelName =="HomePanel")
		{
			//play titles in animation
			transform.Find ("HomePanel/CHOOSE YOUR").GetComponent<Animator>().Play ("TitleEnterLeft");
			transform.Find ("HomePanel/EXPERIENCE").GetComponent<Animator>().Play ("TitleEnterRight");
		}
	}

	private void SetEnvironmentScreen(string page){
		switch (page)
		{
		case "Ocean":
			background = Resources.Load("BgImages/ocean-background") as Texture2D;
			title = "OCEAN";
			subtitle = "SUBMARINES - BOATS";
			infoText = "Sail, submerge, or splash across the vast blue ocean. From the deepest depths to the shimmering surface, let us bring your ocean adventure to motion by combining stunning visuals and sounds with one of our popular immersive devices below.";
			scrollImage = Resources.Load("PhotoStacks/Ocean-Photo-Stack") as GameObject;
			//hide g-force
			gForce.SetActive(false);
			break;
		case "Land":
			background = Resources.Load("BgImages/land-background") as Texture2D;
			title = "LAND";
			subtitle = "RACE CARS - MOTORCYCLES - TRUCKS";
			infoText = "Race or rocket past a stadium of your fans, the countryside or an exotic terrain. Let us bring your racing adventure to the finish line with stunning visuals and sound.";
			scrollImage = Resources.Load("PhotoStacks/Land-Photo-Stack") as GameObject;
			break;
		case "Aviation":
			background = Resources.Load("BgImages/aviation-background") as Texture2D;
			title = "AVIATION";
			subtitle = "JETS - AIRCRAFTS - HELICOPTERS";
			infoText = "From prop planes to jet fighters, and everything in between, we know the air above calls your name. Let us bring your aircraft adventures to life with our aerodynamics models, stunning visuals, surround sound, and immersive platforms.";
			scrollImage = Resources.Load("PhotoStacks/Aviation-Photo-Stack") as GameObject;
			photoPanel = Resources.Load ("PhotoStacks/Aviation-Full-Screen") as GameObject;
			break;
		case "Space":
			background = Resources.Load("BgImages/space-background") as Texture2D;
			title = "SPACE";
			subtitle = "SUBORBITAL - ORBITAL";
			infoText = "From spacecraft to space stations, let us bring your unique space adventure to motion by combining stunning visuals and sounds with one of our popular immersive devices below.";
			scrollImage = Resources.Load("PhotoStacks/Space-Photo-Stack") as GameObject;
			break;
		case "Beyond":
			background = Resources.Load("BgImages/beyond-background") as Texture2D;
			title = "BEYOND";
			subtitle = "MARS - ASTEROIDS - DEEP SPACE";
			infoText = "From Martian rovers to starships of the future, let us bring your galactic adventure to motion by combining stunning visuals and sounds with one of our popular immersive devices below.";
			scrollImage = Resources.Load("PhotoStacks/Beyond-Photo-Stack") as GameObject;
			break;
		}

		//set background
		transform.Find("BackgroundCamera/BackgroundImage").GetComponent<SpriteRenderer>().sprite = Sprite.Create (background, new Rect(0, 0, 2048, 1536), new Vector2(0.5f,0.5f));
		//set title panel (title, subtitle, text block)
		transform.Find("EnvironmentPanel/Title Panel/Title").GetComponent<Text>().text = title;
		transform.Find("EnvironmentPanel/Title Panel/Subtitle").GetComponent<Text>().text = subtitle;
		transform.Find("EnvironmentPanel/Title Panel/Text").GetComponent<Text>().text = infoText;
		//enable & assign scroll panel + prefab height
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().enabled = true;
		transform.Find("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().scrollImagePrefab = scrollImage;
		//enable & assign scroll panel photo zooms
		 //transform.Find ("EnvironmentPanel/Scroll Images").GetComponent<LoopImageStack>().photoPanelPrefab = photoPanel;
	}

	private void SetProductScreen(string page){
		switch (page)
		{
		case "ATFS400":
			title = "ATFS-400";
			subtitle = "CENTRIFUGE";
			infoText = " ";
			mediaPanel = Resources.Load("MediaPanels/ATFS400-Media") as GameObject;
			break;
		case "GAT":
			title = "GAT";
			subtitle = "GENERAL AVIATON TRAINER";
			infoText = " ";
			mediaPanel = Resources.Load("MediaPanels/GAT-Media") as GameObject;
			break;
		case "GL2000":
			title = "GL-2000";
			subtitle = "GYROLAB";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/GL2000-Media") as GameObject;
			break;
		case "GL4000":
			title = "GL-4000";
			subtitle = "GYROLAB";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/GL4000-Media") as GameObject;
			break;
		case "GL6000":
			title = "GL-6000";
			subtitle = "GYROLAB";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/GL6000-Media") as GameObject;
			break;
		case "IPT2":
			title = "IPT2";
			subtitle = "INTEGRATED PHYSIO TRAINER";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/IPT2-Media") as GameObject;
			break;
		case "IPT3":
			title = "IPT3";
			subtitle = "INTEGRATED PHYSIO TRAINER";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/IPT3-Media") as GameObject;
			break;
		case "XForce":
			title = "XFORCE";
			subtitle = "MULTI-ARM CENTRIFUGE";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/XForce-Media") as GameObject;
			break;
		case "XSpeed":
			title = "XSPEED";
			subtitle = "MOTION PLATFORM";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/XSpeed-Media") as GameObject;
			break;
		case "XVector":
			title = "XVECTOR";
			subtitle = "MONSTER ROLL CAGE";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/XVector-Media") as GameObject;
			break;
		case "NonMotion":
			title = "NON-MOTION";
			subtitle = "PRODUCTS";
			infoText = " ";
			mediaPanel = Resources.Load ("MediaPanels/NonMotion-Media") as GameObject;
			break;
		}

		//set title panel (title, subtitle, text block)
		transform.Find("ProductPanel/Title Panel/Title").GetComponent<Text>().text = title;
		transform.Find("ProductPanel/Title Panel/Subtitle").GetComponent<Text>().text = subtitle;
		transform.Find("ProductPanel/Title Panel/Text").GetComponent<Text>().text = infoText;

		//photo panels
		GameObject myMediaPanel = Instantiate(mediaPanel);
		myMediaPanel.transform.SetParent(transform.Find("ProductPanel/Media"), false);
	}
}
