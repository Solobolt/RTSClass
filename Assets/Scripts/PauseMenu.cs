using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject pauseScreen;
	private GameObject currentScreen;
	private bool paused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PauseControls ();
	}

	void PauseControls()
	{
		if(Input.GetKeyDown("escape"))
		{
			togglePause();
		}
	}

	public void togglePause()
	{
		if(paused == false)
		{
			paused = true;
			currentScreen = Instantiate (pauseScreen) as GameObject;
			Time.timeScale = 0;
		}
		else
		{
			paused = false;
			Destroy (currentScreen);
			Time.timeScale = 1;
		}
	}
}
