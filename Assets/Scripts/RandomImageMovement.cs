using UnityEngine;
using System.Collections;

public class RandomImageMovement : MonoBehaviour {

	private Vector2 origin;

	private float left_bound;
	private float right_bound;
	private float top_bound;
	private float bottom_bound;

	private Vector2 AI_position;

	public float speed = 5.0f;
	public Vector3 direction;
	
	void Start() 
	{
		left_bound = GetComponent<RectTransform>().anchoredPosition.x - 50;
		right_bound = GetComponent<RectTransform>().anchoredPosition.x + 50;
		top_bound = GetComponent<RectTransform>().anchoredPosition.y - 50;
		bottom_bound = GetComponent<RectTransform>().anchoredPosition.y + 50;

		direction = (new Vector3(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f),0.0f)).normalized;
		transform.Rotate(direction);
	}
	
	void Update()
	{
		Vector2 newPos = transform.position + direction * speed * Time.deltaTime;
		Debug.Log (newPos);
		//GetComponent<RectTransform>().MovePosition (newPos);
		//this.GetComponent<RectTransform>().anchoredPosition += newPos;

		AI_position = this.GetComponent<RectTransform>().anchoredPosition;
		if(AI_position.x < left_bound || AI_position.x > right_bound || AI_position.y > top_bound || AI_position.y < bottom_bound){
			Debug.Log ("BOUNCE");
		}
	}
	
}
