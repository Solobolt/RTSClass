using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private int health = 100;

    private int gold = 0;
    public int gainAmount = 5;
    private int startingGoldAmount = 100;

    public int UIGold;

    private float gainRate = 1.0f;
    private float timer;

    public int enemyCount = 0;

	// Use this for initialization
	void Start () {
        gold += startingGoldAmount;
	}
	
	// Update is called once per frame
	void Update () {
        AddGain(gainAmount);
	}
    //adds gold every second
    public void AddGain(int amount)
    {
        if(timer >= gainRate)
        {
            gold += amount;
            UIGold = gold;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    //adds to the amount of gold that the player inherently gets
    public void IncreaseGain(int amount)
    {
        gainAmount += amount;
    }

    //takes gold away from the players current amount
    public void RemoveGold(int amount)
    {
        gold -= amount;
        UIGold = gold;
    }

    //give gold to the players current amount
    public void AddGold(int amount)
    {
        gold += amount;
        UIGold = gold;
    }
}
