using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_camera : MonoBehaviour {

	Vector2 mouseStart = new Vector2(0,0);
	float moveSpeed = 0.001f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			mouseStart.x = Input.mousePosition.x;
			mouseStart.y = Input.mousePosition.y;
		}
		if(Input.GetMouseButtonUp(0))
		{
			mouseStart.x = 0;
			mouseStart.y = 0;
		}
		if(mouseStart.x != 0 && Camera.current != null)
		{
			//Camera.current.transform.Translate(new Vector3((Input.mousePosition.x - mouseStart.x)*moveSpeed, 0.0f, (mouseStart.y - Input.mousePosition.y)*moveSpeed));
			Camera.current.transform.position = 
				new Vector3(
					Camera.current.transform.position.x + (Input.mousePosition.x - mouseStart.x)*moveSpeed, 
					Camera.current.transform.position.y, 
					Camera.current.transform.position.z + (Input.mousePosition.y - mouseStart.y)*moveSpeed);
		}
	}
}
