﻿using UnityEngine;

public class DragImages : MonoBehaviour
{
	// This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)
	//public LayerMask mask = UnityEngine.Physics.DefaultRaycastLayers;
	
	// This stores the finger that's currently dragging this GameObject
	private Lean.LeanFinger draggingFinger;

	private GameObject colliderObject;

	void Start(){
		colliderObject = transform.parent.gameObject;
	}

	protected virtual void OnEnable()
	{
		// Hook into the OnFingerDown event
		Lean.LeanTouch.OnFingerDown += OnFingerDown;
		
		// Hook into the OnFingerUp event
		Lean.LeanTouch.OnFingerUp += OnFingerUp;

	}
	
	protected virtual void OnDisable()
	{
		// Unhook the OnFingerDown event
		Lean.LeanTouch.OnFingerDown -= OnFingerDown;
		
		// Unhook the OnFingerUp event
		Lean.LeanTouch.OnFingerUp -= OnFingerUp;
	}
	

	protected virtual void Update()
	{
		// If there is an active finger, move this GameObject based on it
		if (draggingFinger != null)
		{
			Lean.LeanTouch.MoveObject(transform, draggingFinger.DeltaScreenPosition);
		}
	}
	
	public void OnFingerDown(Lean.LeanFinger finger)
	{
		draggingFinger = finger;

		/*
		// Raycast information
		var ray = finger.GetRay();
		var hit = default(RaycastHit);

		Debug.Log(Physics.Raycast(ray, out hit, float.PositiveInfinity, mask));
		Debug.Log ("ray= " + ray + "  hit= " + hit + "   mask= " + mask);
		
		// Was this finger pressed down on a collider?
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity, mask) == true)
		{
			Debug.Log ("in one");
			// Was that collider this one?
			if (hit.collider.gameObject == gameObject)
			{
				Debug.Log ("in two");
				// Set the current finger to this one
				draggingFinger = finger;
			}
		}*/
	}
	
	public void OnFingerUp(Lean.LeanFinger finger)
	{
		Debug.Log("FINGER UP");
		// Was the current finger lifted from the screen?
		if (finger == draggingFinger)
		{
			// Unset the current finger
			draggingFinger = null;
		}

	}
}