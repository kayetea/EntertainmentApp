using UnityEngine;
using System.Collections;

public class LoopImageStack : MonoBehaviour {

	public float speed = 1;
	public GameObject scrollImagePrefab;
	private GameObject prefab1;
	private GameObject prefab2;

	public int prefabHeight;

	void Start () {
		//create first stack and parent it to canvas
		prefab1 = Instantiate(scrollImagePrefab) as GameObject;
		prefab1.transform.SetParent(this.transform, false);

		//creates second stack, parents to canvas, and places under prefab1
		prefab2 = Instantiate(scrollImagePrefab) as GameObject;
		prefab2.transform.SetParent(this.transform, false);
		Vector2 pos = prefab2.GetComponent<RectTransform>().anchoredPosition;
		pos.y -= prefabHeight;
		prefab2.GetComponent<RectTransform>().anchoredPosition = pos;

	}

	void Update () {
		//MOVE IMAGES UPWARDS OVER TIME
		Move(prefab1);
		Move(prefab2);

		//MOVE TOP STACK TO BOTTOM WHEN OFF SCREEN
		if(prefab1.GetComponent<RectTransform>().anchoredPosition.y > prefabHeight)
		{
			Vector2 pos1 = prefab1.GetComponent<RectTransform>().anchoredPosition;
			Vector2 pos2 = prefab2.GetComponent<RectTransform>().anchoredPosition;
			pos1.y = pos2.y - prefabHeight;
			prefab1.GetComponent<RectTransform>().anchoredPosition = pos1;
		}

		if(prefab2.GetComponent<RectTransform>().anchoredPosition.y > prefabHeight)
		{
			Vector2 pos2 = prefab2.GetComponent<RectTransform>().anchoredPosition;
			Vector2 pos1 = prefab1.GetComponent<RectTransform>().anchoredPosition;
			pos2.y = pos1.y - prefabHeight;
			prefab2.GetComponent<RectTransform>().anchoredPosition = pos2;
		}

	}

	private void Move(GameObject prefab){
		Vector2 pos = prefab.GetComponent<RectTransform>().anchoredPosition;
		pos.y += 1 * speed * Time.deltaTime;
		prefab.GetComponent<RectTransform>().anchoredPosition = pos;
	}
	

}
