using UnityEngine;
using System.Collections;

public class OpenScene : MonoBehaviour {

	public string levelName;


	//Activates when object is clicked
	public void OpenSceneOnClick(){
		ApplicationModel.previousLevel = Application.loadedLevelName;
		Debug.Log ("LOAD NEW SCENE");
		ApplicationModel.currentLevel = levelName;
		Application.LoadLevel (levelName);
	}

}
