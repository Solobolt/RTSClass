using UnityEngine;
using System.Collections;

public class PauseControls : MonoBehaviour {
	PauseMenu pauseMenu;

	// Use this for initialization
	void Start () {
		pauseMenu = GameObject.FindGameObjectWithTag ("UIController").GetComponent<PauseMenu> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void resumeGame()
	{
		pauseMenu.togglePause ();
	}

	public void loadLevel(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}

	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
