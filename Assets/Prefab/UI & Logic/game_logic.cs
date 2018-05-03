using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_logic : MonoBehaviour {

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

	public int nbSavedChickhorn;

	void Start(){
		loseText.gameObject.SetActive(false);
		loseButton.gameObject.SetActive(false);

		winText.gameObject.SetActive(false);
		winButton.gameObject.SetActive(false);
	}
	void Update () {
		chickenCount = GameObject.FindGameObjectsWithTag("Chicken").Length;
		countText.text = (nb_chicken_win - nbSavedChickhorn).ToString() + " chickhorn to save";

		if(chickenCount < 2 && hasWon != true)
		{
			if (nbSavedChickhorn + chickenCount < nb_chicken_win) {
				loseText.gameObject.SetActive(true);
				loseButton.gameObject.SetActive(true);
			}
		} 
		if(nbSavedChickhorn >= nb_chicken_win)
		{
			hasWon = true;
			winText.gameObject.SetActive(true);
			winButton.gameObject.SetActive(true);
		}
	}
	public void IncrementSavedChickhorn(){
		nbSavedChickhorn++;
	}
	public void loseScene(){
		SceneManager.LoadScene("FF_Menu", LoadSceneMode.Single);
	}

	public void nextScene(){
		// SceneManager.LoadScene("same level but with harder settings", LoadSceneMode.Single);
		SceneManager.LoadScene("FF_Menu", LoadSceneMode.Single);
	}
}
