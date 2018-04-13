using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class scene_loader : MonoBehaviour {

	public void LoadScene (string scene) {
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}

}
