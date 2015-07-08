using UnityEngine;
using System.Collections;

public class LoopImageStack : MonoBehaviour {

	public float speed = 1;
	public GameObject scrollImagePrefab;
	private GameObject prefab1;
	private GameObject prefab2;

	public int prefabHeight;


	// Use this for initialization
	void Start () {
		//create first stack and parent it to canvas
		prefab1 = Instantiate(scrollImagePrefab) as GameObject;
		prefab1.transform.SetParent(this.transform, false);

		prefab2 = Instantiate(scrollImagePrefab) as GameObject;
		prefab2.transform.SetParent(this.transform, false);
		Vector3 pos = prefab2.transform.position;
		pos.y -= prefabHeight;
		prefab2.transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {
		//MOVE IMAGES UPWARDS OVER TIME

		Move(prefab1);
		Move(prefab2);

		//MOVE TOP STACK TO BOTTOM WHEN OFF SCREEN
		if(prefab1.transform.position.y > prefabHeight*2)
		{
			Vector3 pos1 = prefab1.transform.position;
			Vector3 pos2 = prefab2.transform.position;
			pos1.y = pos2.y - prefabHeight;
			prefab1.transform.position = pos1;
		}

		if(prefab2.transform.position.y > prefabHeight*2)
		{
			Vector3 pos2 = prefab2.transform.position;
			Vector3 pos1 = prefab1.transform.position;
			pos2.y = pos1.y - prefabHeight;
			prefab2.transform.position = pos2;
		}

	}

	private void Move(GameObject prefab){
		Vector3 pos = prefab.transform.position;
		pos.y += 1;
		prefab.transform.position = pos;
	}

}
