using System;
using UnityEngine;
using UnityEngine.UI;

public class SliderArrows : MonoBehaviour {

	public Scrollbar scrollTarget;
	public Button otherArrow;
	public float Step = 0.1f;

	public float HoldFrequency = 0.1f;
	public bool incrementBool;

	void Start()
	{
		scrollTarget.value = 0;

	}

	public void Increment()
	{
		scrollTarget.value = Mathf.Clamp(scrollTarget.value + Step, 0, 1);
		GetComponent<Button>().interactable = scrollTarget.value != 1;
		otherArrow.interactable = true;
	}
	
	public void Decrement()
	{
		scrollTarget.value = Mathf.Clamp(scrollTarget.value - Step, 0, 1);
		GetComponent<Button>().interactable = scrollTarget.value != 0;
		otherArrow.interactable = true;
	}


	public void OnPointerDown(bool increment)
	{
		if (increment)
		{
			incrementBool = true;
		}
		InvokeRepeating("IncrementDecrementSequence", 0.5f, HoldFrequency);
	}
	
	public void OnPointerUp()
	{
		CancelInvoke("IncrementDecrementSequence");
	}
	
	public void IncrementDecrementSequence()
	{
		if(incrementBool) Increment();
		else          Decrement();
	}
}
