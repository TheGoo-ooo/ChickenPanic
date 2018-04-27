using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf : MonoBehaviour {

	public float maxX=35f; // 35 is quite a long distance.
	public float speed=0.05f; // 0.1 is quite fast.

	// Update is called once per frame
	void Update () {
		transform.position= new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
		if (transform.position.x > maxX)
			Destroy (this.gameObject);
	}
}
