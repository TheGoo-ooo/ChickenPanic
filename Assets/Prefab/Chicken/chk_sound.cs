using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chk_sound : MonoBehaviour {

	GameObject soundObject;
	// Use this for initialization
	void Start () {
		Random.seed += 1;
		Invoke("PlayChickhornSound", Random.Range(0.01f, 5.0f));
		if (!soundObject) soundObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlayChickhornSound(){
		if (!soundObject.GetComponent<AudioSource> ().isPlaying)
			soundObject.GetComponent<AudioSource> ().pitch = Random.Range(0.9f, 1.8f);
			soundObject.GetComponent<AudioSource>().Play();
		Invoke("PlayChickhornSound", Random.Range(6.0f, 12.0f));
	}
}
