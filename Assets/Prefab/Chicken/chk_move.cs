using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chk_move : MonoBehaviour {

	private const float FORCE = 100;
	private const float JUMP_FORCE = 180;
	private const float INTERVAL_TIME = 0.1f;
	private const float MOVE_CHANCE = 0.5f;
	private const float JUMP_CHANCE = 0.2f;

	private Rigidbody rb;
	private float deltaTime = 0;
	public Vector3 moveForce = Vector3.zero;

	private int currentDirection = 0;
	private Vector2[] directions = {
		new Vector2 (0, 1),
		new Vector2 (1, 1),
		new Vector2 (1, 0),
		new Vector2 (1, -1),
		new Vector2 (0, -1),
		new Vector2 (-1, -1),
		new Vector2 (-1, 0),
		new Vector2 (-1, 1),
	};

	void Start () {
		rb = GetComponent<Rigidbody> ();
		Random.InitState (this.GetHashCode ());
	}


	void Update () {
		deltaTime += Time.deltaTime;
		if (deltaTime >= INTERVAL_TIME) {
			deltaTime = 0;
			MoveChicken ();
		}
		transform.rotation = Quaternion.Euler (0f, currentDirection * 360 / 7.0f, 0);
	}

	private void MoveChicken (){
		if (Random.value < MOVE_CHANCE && moveForce == Vector3.zero)
		{
			currentDirection = (int)(Random.value * 7.5f);
			Vector2 dir =  directions [currentDirection];
			dir *= FORCE;
			moveForce.x = dir.x;
			moveForce.y = 0.0f;
			moveForce.z = dir.y;
		} else
		{
			moveForce = Vector3.zero;
			rb.velocity -= rb.velocity * 0.2f;
			rb.angularVelocity = Vector3.zero;
		}
		if (Random.value < JUMP_CHANCE && rb.velocity.y == 0) {
			moveForce.y = JUMP_FORCE;
		}
		rb.AddForce (moveForce);

	}
}
