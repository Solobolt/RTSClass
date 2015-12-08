using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadScene(string sceneName)
	{
		Application.LoadLevel (sceneName);
	}

	public void quitGame()
	{
		Application.Quit ();
	}

}
