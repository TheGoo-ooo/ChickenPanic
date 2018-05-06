using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class graine : MonoBehaviour {

	public int speed = 3;
	public int radius = 15;
	public int deathCountrer = 3;

	void Start () {
	}

	void Update () {
		Collider[] colliders = Physics.OverlapSphere (transform.position, radius);
		foreach (var collider in colliders) {
			if (collider.gameObject.tag == "Chicken") {
				Rigidbody rb = collider.GetComponent<Rigidbody> ();
				Vector3 vec = transform.position-collider.transform.position;
				Vector3 direction = Vector3.Normalize (vec);
				rb.AddForce (direction*speed);
				collider.transform.LookAt(transform);
			}
		}
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Chicken") {
			deathCountrer--;
			if (deathCountrer <= 0) {
				Destroy (this.gameObject);
			}
		}
	}
}
