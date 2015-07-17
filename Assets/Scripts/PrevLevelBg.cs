using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrevLevelBg : MonoBehaviour {
	/*public RawImage rawImage; 

	public Texture2D oceanBg;
	public Texture2D landBg;
	public Texture2D aviationBg;
	public Texture2D spaceBg;
	public Texture2D beyondBg;*/

	public Sprite oceanBg;
	public Sprite landBg;
	public Sprite aviationBg;
	public Sprite spaceBg;
	public Sprite beyondBg;

	// Use this for initialization
	void Start () {


		/*switch (ApplicationModel.previousLevel)
		{
			case "Ocean":
				rawImage.texture = oceanBg;
				break;
			case "Land":
				rawImage.texture = landBg;
				break;
			case "Aviation":
				rawImage.texture = aviationBg;
				break;
			case "Space":
				rawImage.texture = spaceBg;
				break;
			case "Beyond":
					rawImage.texture = beyondBg;
				break;
		}
	*/

		switch (ApplicationModel.previousLevel)
		{
		case "Ocean":
			GetComponent<SpriteRenderer>().sprite = oceanBg;
			break;
		case "Land":
			GetComponent<SpriteRenderer>().sprite = landBg;
			break;
		case "Aviation":
			GetComponent<SpriteRenderer>().sprite = aviationBg;
			break;
		case "Space":
			GetComponent<SpriteRenderer>().sprite = spaceBg;
			break;
		case "Beyond":
			GetComponent<SpriteRenderer>().sprite = beyondBg;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
