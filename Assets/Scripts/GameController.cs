using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private int health = 100;

    private int gold = 0;
    private int gainAmount = 1;
    private int startingGoldAmount = 100;

    public int UIGold;

    private float gainRate = 1.0f;
    private float timer;

	// Use this for initialization
	void Start () {
        gold += startingGoldAmount;
	}
	
	// Update is called once per frame
	void Update () {
        AddGain();
	}
    //adds gold every second
    void AddGain()
    {
        if(timer >= gainRate)
        {
            gold += gainAmount;
            UIGold = gold;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
