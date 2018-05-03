using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_logic2 : MonoBehaviour {

	// Difficutly settings.
	private int difficulty;
	private int nb_chicken_win = 10;

	private int chickenCount;
	private bool hasWon = false;


	// Inputs.
	public Text countText;
	public Text winText;
	public Text loseText;
	public Button winButton;
	public Button loseButton;
	public Button retryButton;
	public string winSceneName = "MainMenu";
	public string loseSceneName = "MainMenu";
	public string retrySceneName = "tuto1";

	void Start(){
		loseText.gameObject.SetActive(false);
		loseButton.gameObject.SetActive(false);
		if(retryButton != null)
			retryButton.gameObject.SetActive(false);

		winText.gameObject.SetActive(false);
		winButton.gameObject.SetActive(false);
	}
	void Update () {
		chickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
		countText.text = (nb_chicken_win - chickenCount).ToString() + " chickhorn to breed";

		if(chickenCount < 2 && hasWon != true)
		{
			loseText.gameObject.SetActive(true);
			loseButton.gameObject.SetActive(true);
			if (retryButton != null)
				retryButton.gameObject.SetActive (true);
		} 
		if(chickenCount >= nb_chicken_win)
		{
			hasWon = true;
			winText.gameObject.SetActive(true);
			winButton.gameObject.SetActive(true);
		}
	}
	public void loseScene(){
		SceneManager.LoadScene(loseSceneName, LoadSceneMode.Single);
	}
	public void nextScene(){
		SceneManager.LoadScene(winSceneName, LoadSceneMode.Single);
	}
	public void retryScene(){
		SceneManager.LoadScene(retrySceneName, LoadSceneMode.Single);
	}
}
