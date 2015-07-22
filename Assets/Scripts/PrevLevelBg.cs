using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrevLevelBg : MonoBehaviour {

	public Sprite oceanBg;
	public Sprite landBg;
	public Sprite aviationBg;
	public Sprite spaceBg;
	public Sprite beyondBg;

	// Use this for initialization
	void Start () {

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
