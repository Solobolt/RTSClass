using UnityEngine;
using System.Collections;

public abstract class Tower : MonoBehaviour {

    public GameController gameController;

    public int cost;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.RemoveGold(cost);
        StartTowerEffect();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateTowerEffect();
	}

    public GameController getGameController()
    {
        return GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public abstract void StartTowerEffect();
    public abstract void UpdateTowerEffect();
}
