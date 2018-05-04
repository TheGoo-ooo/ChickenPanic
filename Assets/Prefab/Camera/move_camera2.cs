using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera2 : MonoBehaviour {

	public float moveSpeed = 0.3f;
	public float borderRange = 0.18f;
	private float borderRangeX = 0f;
	private float borderRangeY = 0f;
	private bool move = false;
	float x, y, z;

	void Start(){
		borderRangeX = Screen.width * borderRange;
		borderRangeY = Screen.height * borderRange;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0))
			move = true;
		else if (Input.GetMouseButtonUp(0))
			move = false;

		if (move)
			moveCamera ();

	}

	private void moveCamera (){
		if (Input.mousePosition.x < borderRangeX) {
			x = -1 * moveSpeed;
		} else if (Input.mousePosition.x > Screen.width - borderRangeX)
			x = 1 * moveSpeed;
		else
			x = 0;

		if (Input.mousePosition.y < borderRangeY)
			y = -1 * moveSpeed;
		else if (Input.mousePosition.y > Screen.height - borderRangeY)
			y = 1 * moveSpeed;
		else
			y = 0;

		if (Camera.current != null) {
			Camera.current.transform.position = 
				new Vector3 (
				Camera.current.transform.position.x + x, 
				Camera.current.transform.position.y, 
				Camera.current.transform.position.z + y);
		}
	}
}
