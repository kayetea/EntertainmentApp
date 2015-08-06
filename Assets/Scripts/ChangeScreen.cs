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
	private Texture2D background;
	private string title;
	private string subtitle;
	private string infoText;
	private GameObject scrollImage;


	//Product Variables
	private GameObject mediaPanel;
	
	/*[Header("Ocean")]
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
	public GameObject xvectorMedia;*/

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
			background = Resources.Load("BgImages/ocean-background") as Texture2D;
			title = "OCEAN";
			subtitle = "SUBMARINE - BOATS";
			infoText = "Sail, submerge, or splash across the vast blue ocean. From the deepest depths to the shimmering surface, let us bring your adventure to motion by combining stunning visuals and sounds, with one of our popular immersive motion or non-motion devices below.  ";
			scrollImage = Resources.Load("PhotoStacks/Ocean-Photo-Stack") as GameObject;
			break;
		case "Land":
			background = Resources.Load("BgImages/land-background") as Texture2D;
			title = "LAND";
			subtitle = "RACE CARS - MOTORCYCLES - TRUCKS";
			infoText = "Race or rocket past a stadium of your fans, the countryside, or exotic terrain. Able to model your 4x4 to elite jet racing cars, let us bring your adventure to motion! With stunning visuals and sound, please choose an immersive experience platform or device below.";
			scrollImage = Resources.Load("PhotoStacks/Land-Photo-Stack") as GameObject;
			break;
		case "Aviation":
			background = Resources.Load("BgImages/aviation-background") as Texture2D;
			title = "AVIATION";
			subtitle = "JET - AIRCRAFT - HELICOPTER";
			infoText = "From prop planes to jet fighters, and everything in between, we know the air above calls your name. We bring your aircraft (and adventures!) to life. With aerodynamics models, stunning visuals, surround sound, and full immersive motion (or non-motion) platform, we’ll get you back in the sky real soon…  ";
			scrollImage = Resources.Load("PhotoStacks/Aviation-Photo-Stack") as GameObject;
			break;
		case "Space":
			background = Resources.Load("BgImages/space-background") as Texture2D;
			title = "SPACE";
			subtitle = "SUBORBITAL - ORBITAL";
			infoText = "The final frontier…experience the breathtaking sensation of rocketing towards the stars and then silent serenity as you gaze upon the curvature of the earth. From spacecraft to space stations, let us bring your unique space adventure to motion by combining stunning visuals and sounds, with one of our popular immersive motion or non-motion devices below.  ";
			scrollImage = Resources.Load("PhotoStacks/Space-Photo-Stack") as GameObject;
			break;
		case "Beyond":
			background = Resources.Load("BgImages/beyond-background") as Texture2D;
			title = "BEYOND";
			subtitle = "MARS - ASTEROIDS - DEEP SPACE";
			infoText = "Mars, Asteroids, and now Pluto. They are beckoning our arrival. From Martian rovers to starships of the future, let us bring your galactic adventure to motion by combining stunning visuals and sounds, with one of our popular immersive motion or non-motion devices below.";
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
	}

	private void SetProductScreen(string page){
		switch (page)
		{
		case "ATFS400":
			title = "ATFS-4000";
			subtitle = "CENTRIFUGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load("MediaPanels/ATFS400-Media") as GameObject;
			break;
		case "GAT":
			title = "GAT";
			subtitle = "SUBTITLE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load("MediaPanels/GAT-Media") as GameObject;
			break;
		case "GL2000":
			title = "GL-2000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			//mediaPanel = gl2000Media;
			break;
		case "GL4000":
			title = "GL-4000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load ("MediaPanels/GL4000-Media") as GameObject;
			break;
		case "GL6000":
			title = "GL-6000";
			subtitle = "GYROLAB";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load ("MediaPanels/GL6000-Media") as GameObject;
			break;
		case "IPT2":
			title = "IPT2";
			subtitle = "INTEGRATED PHYSIOLOGICAL TRAINER";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load ("MediaPanels/IPT2-Media") as GameObject;
			break;
		case "IPT3":
			title = "IPT3";
			subtitle = "INTEGRATED PHYSIOLOGICAL TRAINER";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			mediaPanel = Resources.Load ("MediaPanels/IPT3-Media") as GameObject;
			break;
		case "XForce":
			title = "XFORCE";
			subtitle = "MULTI-ARM CENTRIFUGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			//mediaPanel = xforceMedia;
			break;
		case "XSpeed":
			title = "XSPEED";
			subtitle = "SUBTITLE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			//mediaPanel = xspeedMedia;
			break;
		case "XVector":
			title = "XVECTOR";
			subtitle = "MONSTER ROLL CAGE";
			infoText = "Please provide brief but meaningful text about the product and some of its features. Perhaps even mentioning successful other installations and contracts involving this product.";
			//mediaPanel = xvectorMedia;
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
