/*
LOOPIMAGESTACK.CS

 Creates two prefabs of the "image stacks" and loops them seamlessly 
 while moving them  upward over time. 

REQUIREMENTS:
- Attach to empty panel. 

- Build your prefab by parenting images stacked on top of eachother. Make
sure to set the height of the prefab as the total height of all of the images 
combined. Then fill in this height number as the variable on this script

- Set the speed you'd like the stack to move at. I started at 200 and moved it down to
a comfortable speed. 
*/

using UnityEngine;
using System.Collections;

public class LoopImageStack : MonoBehaviour {

	public float speed = 1;
	public GameObject scrollImagePrefab;
	public GameObject prefab1;
	private GameObject prefab2;
	public GameObject photoPanelPrefab;
	private GameObject photoPanelP;

	private float prefabHeight;

	public bool touchingStack;

	public void Start () {
		prefabHeight = scrollImagePrefab.GetComponent<RectTransform>().rect.height;

		//create first stack and parent it to canvas
		prefab1 = Instantiate(scrollImagePrefab) as GameObject;
		prefab1.transform.SetParent(this.transform, false);

		//creates second stack, parents to canvas, and places under prefab1
		prefab2 = Instantiate(scrollImagePrefab) as GameObject;
		prefab2.transform.SetParent(this.transform, false);
		Vector2 pos = prefab2.GetComponent<RectTransform>().anchoredPosition;
		pos.y -= prefabHeight;
		prefab2.GetComponent<RectTransform>().anchoredPosition = pos;

		//attaches full screen panel
		//photoPanelP = Instantiate (photoPanelPrefab) as GameObject;
		//photoPanelP.transform.SetParent (this.transform, false);

	}


	void Update () {

		if(!prefab1 && !prefab2)
		{
			Start ();
		}

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

	public void MyCollision(bool touch){
		touchingStack = touch;
	}

	private void Move(GameObject prefab){
		//move object upwards over time * speed
		Vector2 pos = prefab.GetComponent<RectTransform>().anchoredPosition;
		pos.y += 1 * speed * Time.deltaTime;
		prefab.GetComponent<RectTransform>().anchoredPosition = pos;
	}

	public void RemoveStacks(){
		if( prefab1 && prefab2){
			Destroy(this.prefab1);
			Destroy(this.prefab2);
		}
	}

}
