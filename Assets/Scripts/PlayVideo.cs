using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public string movieName;
	private float movieTimer;
	private bool videoPlay = false;

	void Start (){
	}

	// Update is called once per frame
	void Update () {

	}

	public void PlayM (){

		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
			Handheld.PlayFullScreenMovie (movieName, Color.black, FullScreenMovieControlMode.Full, FullScreenMovieScalingMode.AspectFit);
		}
	}

}