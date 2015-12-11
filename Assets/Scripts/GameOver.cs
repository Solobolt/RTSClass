using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    //reloads the current scene
    public void RestartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    //Quits the game
    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
