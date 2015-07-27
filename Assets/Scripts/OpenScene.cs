using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenScene : MonoBehaviour {

	public string levelName;


	//Activates when object is clicked
	public void OpenSceneOnClick(){
		ApplicationModel.previousLevel = Application.loadedLevelName;
		Debug.Log ("LOAD NEW SCENE");
		ApplicationModel.currentLevel = levelName;

		StartCoroutine(LevelLoad(levelName));
	}

	//load level after one second delay
	IEnumerator LevelLoad(string name){
		yield return new WaitForSeconds(1f);
		Application.LoadLevel(name);
	}

}
