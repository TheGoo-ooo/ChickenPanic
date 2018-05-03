using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Select chk.
/// Allow the player to interact with the game environement. Use RayTracing.
/// 
/// Credits: https://answers.unity.com/questions/411793/selecting-a-game-object-with-a-mouse-click-on-it.html
/// 
/// By Florian Fasmeyer
/// He-arc neuchâtel, CH
/// mars 2018.
/// </summary>
public class select_chk : MonoBehaviour {

	private float DEFAULT_POS_Y = 0.0f;
	private float POS_Y_OFFSET = 2f;
	// LayerMask: tell what objects (within a layer) can be seen.
	private int layerMask;


	private GameObject chicken = null;
	private RaycastHit hitInfo;
	private float chickenPosY;
	private bool chickenSelected = false; // Used for move_camera.

	void Start () {
		hitInfo = new RaycastHit();
		// All layers but the 8th.
		layerMask = 1 << 8;
		layerMask = ~layerMask;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
			if (hit) 
			{
				if (hitInfo.transform.gameObject.tag == "Chicken")
				{
					chicken = hitInfo.transform.gameObject;
					chickenSelected = true;
				}
			} 
		} else if(Input.GetMouseButtonUp(0)){
			if (chicken != null) {
				//chicken.GetComponent<Collider> ().enabled = true;
				chickenSelected = false;
				chicken = null;
			}
		}

		if (chicken != null) {
			Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),  hitInfo: out hitInfo, maxDistance: 200,layerMask: layerMask);
			chicken.transform.position = new Vector3(
				hitInfo.point.x, 
				DEFAULT_POS_Y + POS_Y_OFFSET, 
				hitInfo.point.z);
			//chicken.GetComponent<Collider>().enabled = false;
		}
	}

	bool getChickenSelected(){
		return chickenSelected;
	}
}
