/*------------------------------------------------------
Project: AR_test
Program: OpenImage.cs
Author: Katelyn Godfrey

Description: 

Updated: 06/02/2015 
------------------------------------------------------

ADD TO PANEL. ASSIGN IMAGES AS NEEDED.

------------------------------------------------------*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpenImage_OLD: MonoBehaviour{
	public GameObject panel;
	public Texture2D[] imageArray;
	private int currentImage = 0;
	public RawImage rawImage; 

	private float changeTime = 2.0f;
	private float currentTime = 1.0f;
	private bool canClose = false;


	void Start() {
		//currentImage = 0;
		rawImage.texture = imageArray[currentImage]; 
		panel.SetActive(false);
	}

	void Update(){
		if (Input.GetKeyUp("left"))
		{
			Debug.Log ("You swiped left!");
			currentImage++;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
		}
		
		if (Input.GetKeyUp("right"))
		{
			Debug.Log ("You swiped right!");
			currentImage--;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
		}

		if(Input.GetMouseButtonDown(0) && canClose)
		{
			panel.SetActive(false);
		}

		//delay being able to close window
		if(currentTime > changeTime){
			canClose = true;
		}
		currentTime +=Time.deltaTime;

	}

	//Open Panel
	public void EnablePanel(int buttonImage){
		panel.SetActive(true);
		currentImage = buttonImage;
		rawImage.texture = imageArray[currentImage];

		currentTime = 0;
		canClose = false;
	}

	//Loop Array
	private void LoopArray(){
		if (currentImage == imageArray.Length) {
			currentImage = 0;
		}
		
		if (currentImage == -1) {
			currentImage = imageArray.Length - 1;
		}
	}


	//CHECK SWIPES & TAP
	protected virtual void OnEnable()
	{
		// Hook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe += OnFingerSwipe;
		Lean.LeanTouch.OnFingerTap += OnFingerTap;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook into the OnSwipe event
		Lean.LeanTouch.OnFingerSwipe -= OnFingerSwipe;
		Lean.LeanTouch.OnFingerTap -= OnFingerTap;
	}

	public void OnFingerTap(Lean.LeanFinger finger)
	{
		Debug.Log("CLOSING WINDOW");
		//close image
		if (canClose){
			panel.SetActive(false);
		}
	}
	
	public void OnFingerSwipe(Lean.LeanFinger finger)
	{
		// Store the swipe delta in a temp variable
		var swipe = finger.SwipeDelta;
		
		if (swipe.x < -Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped left!");
			currentImage++;
			LoopArray();
			rawImage.texture = imageArray[currentImage];

		}
		
		if (swipe.x > Mathf.Abs(swipe.y))
		{
			Debug.Log ("You swiped right!");
			currentImage--;
			LoopArray();
			rawImage.texture = imageArray[currentImage];
			
		}
	}

}