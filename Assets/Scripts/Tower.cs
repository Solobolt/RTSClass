using UnityEngine;
using System.Collections;

public abstract class Tower : MonoBehaviour {

    GameController gameController;

    public int cost;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        gameController.UIGold -= cost;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
