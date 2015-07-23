using UnityEngine;

public class DragImages : MonoBehaviour
{
	// This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)
	//public LayerMask mask = UnityEngine.Physics.DefaultRaycastLayers;
	
	// This stores the finger that's currently dragging this GameObject
	private Lean.LeanFinger draggingFinger;

	private Vector2 deltaPos;

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
			deltaPos = new Vector2(0, draggingFinger.DeltaScreenPosition.y);
			Lean.LeanTouch.MoveObject(transform , deltaPos);
		}
	}


	public void OnFingerDown(Lean.LeanFinger finger)
	{
		draggingFinger = finger;	

	}
	
	public void OnFingerUp(Lean.LeanFinger finger)
	{
		// Was the current finger lifted from the screen?
		if (finger == draggingFinger)
		{
			// Unset the current finger
			draggingFinger = null;
		}

	}
}