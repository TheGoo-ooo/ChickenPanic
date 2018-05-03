using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chk_collide : MonoBehaviour {

	private const float REPRODUCE_INTERVAL = 20;
	private const float REPRODUCE_INTERVAL_VARIATION = 12;
	private const float REPRODUCE_COOLDOWN_SPEED_UP = 8;
	private const float REPROCUDE_CHANCE = 0.0f;

	private game_logic myGameLogic;

	private float reproduceInterval;
	SphereCollider cld;
	private float time = 1;

	void Start () {
		cld = GetComponent<SphereCollider> ();
		reproduceInterval = REPRODUCE_INTERVAL + Random.Range (-1, 1) * REPRODUCE_INTERVAL_VARIATION;

		time = Time.time;
	}

	void Update () {

	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Lethal") {
			Die ();
		} else if (col.gameObject.tag == "SavingZone") {
			myGameLogic = GameObject.FindObjectOfType(typeof(game_logic)) as game_logic;
			myGameLogic.IncrementSavedChickhorn();
			//myGameLogic.IncrementSavedChickhorn();
			Die ();
		} else if (col.gameObject.tag == "Chicken") {
			Reproduce ();
		}
	}

	private void Die()
	{
		Debug.Log ("Chicken died!");
		Destroy (this.gameObject);
	}

	private void Reproduce()
	{
		if (Time.time - time > reproduceInterval) {
			if (REPROCUDE_CHANCE > 0) {
				TestReproduction ();
			} else {
				SpawnChicken ();
			}
			time = Time.time;
		}
	}

	private void TestReproduction(){
		time = Time.time+REPRODUCE_COOLDOWN_SPEED_UP;
		if(Random.value < REPROCUDE_CHANCE)
		{
			SpawnChicken ();
		}
	}

	private void SpawnChicken(){
		Debug.Log ("Chicken reproduced!");
		GameObject baby = Instantiate(gameObject);
		Transform trf = baby.transform;
		trf.position = new Vector3(trf.position.x+0.5f, trf.position.y+0.8f, trf.position.z);
	}
}
