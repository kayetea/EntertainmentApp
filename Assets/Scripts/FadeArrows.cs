using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeArrows : MonoBehaviour {

	public Button leftArrow;
	public Button rightArrow;

	public Scrollbar scrollTarget;

	void Start(){
		CheckButtons ();
	}

	public void CheckButtons()
	{
		if(scrollTarget.value == 0)
		{
			leftArrow.interactable = false;
		}
		if(scrollTarget.value == 1)
		{
			rightArrow.interactable = false;
		}
		if(scrollTarget.value > 0 && scrollTarget.value < 1)
		{
			leftArrow.interactable = true;
			rightArrow.interactable = true;
		}
	}
}
