using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {

	public string movieName;
	public MovieTexture movie;
	private float movieTimer;
	private bool videoPlay = false;

	void Start (){
	}

	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0) && movie.isPlaying)
		{
			movie.Stop();
			Debug.Log ("STOP");
			videoPlay = false;
		}
	}

	public void PlayM (){

		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){
#if !UNITY_WEBPLAYER
			Handheld.PlayFullScreenMovie (movieName, Color.black, FullScreenMovieControlMode.CancelOnInput, FullScreenMovieScalingMode.AspectFit);
#endif
		}
		else{
			Debug.Log ("PLAY VIDEO");	
			videoPlay = true;
		}
	}

	void OnGUI(){
		if(videoPlay){
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),movie);
			movie.Play ();
		}
	}
}
