using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public Player player;
	public PlayerSpawn PlayerSpawnScript;

	public bool paused = false;
	private bool changedState = false; // This bool is used to execute unpausing only once

	//Starts by setting pause to false
	void Start () {

		PauseUI.SetActive (false);

	}

	//Checks if the pause button is pressed
	void Update (){

		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		// Pause
		if (paused) {
			changedState = false;
			PauseUI.SetActive (true);
			Time.timeScale = 0;
		}

		// Unpause
		if (!paused && !changedState) {
			changedState = true;
			PauseUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	//Buttons that death and pause screen use
	public void Resume(){

		paused = false;
	}

	public void Restart(){
		
		//player.transform.position = player.spawnPos;

//		PlayerSpawnScript.SetSpawn (new Vector3 (-44, 55, 0)); // sets default spawn on restart

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu(){

		SceneManager.LoadScene(0);
	}

	public void Quit(){

		Application.Quit ();
	}
}
