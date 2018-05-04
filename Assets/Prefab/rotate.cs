using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public Vector3 rotation = new Vector3(0.0f,0.0f,0.0f);

	void Update () {
		transform.Rotate (rotation);

	}
}
