using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSpawner : MonoBehaviour {

	public GameObject wolf;
	public float firstSpawn = 2f; // Time before the first spawn in seconds.
	public float spawnInterval = 20f; // Time before we respawna new wolf.

	private float deltaTime = 0f;
	private bool hasStarted = false; // True after the first spawn.

	// Use this for initialization
	void Start () {
		wolf.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		deltaTime += Time.deltaTime;
		if (!hasStarted && deltaTime >= firstSpawn) {
			spawn ();
			deltaTime = 0f;
			hasStarted = true;
		}
		else if (deltaTime >= spawnInterval) {
			spawn ();
			deltaTime = 0f;
		}
	}

	void spawn(){
		GameObject baby = Instantiate(wolf);
		Transform trf = baby.transform;
		trf.position = transform.position;
		baby.SetActive (true);
	}
}
