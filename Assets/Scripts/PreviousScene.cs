using UnityEngine;
using System.Collections;

public class PreviousScene : MonoBehaviour {

	private string loadScene;

	//Activates when object is clicked
	public void OpenSceneOnClick(){
		Debug.Log ("LOAD " + ApplicationModel.previousLevel);
		loadScene = ApplicationModel.previousLevel;
		ApplicationModel.previousLevel = Application.loadedLevelName;

		Application.LoadLevel(loadScene);
	}
}
