using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrevLevelText : MonoBehaviour {
	private string textReplacement;
	Text themeName;

	// Use this for initialization
	void Start () {
		textReplacement = "Theme: " + ApplicationModel.previousLevel;
		themeName = this.GetComponent<Text>();
		themeName.text = textReplacement;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
