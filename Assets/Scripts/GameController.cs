using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    //holds the UI prefab that is called When you die
    public GameObject gameOverScreen;

    //sets the players health
    public float health = 100;
    private float maxHealth;
    private float healthRatio;

    //Sets the gold values of the player
    private int gold = 0;
    public int gainAmount = 5;
    private int startingGoldAmount = 100;

    //An object that you can refracne without accidently changing the actual gold amount
    public int UIGold;

    //Hold the amount of gold that you recieve every timer tick
    private float gainRate = 1.0f;
    private float timer;

    //number of enemies still in play
    public int enemyCount = 0;
    public List<GameObject> enemies;

    //sets the size of the area that towers can be placed
    private GameObject map;
    public float mapSize = 25;

    // Use this for initialization
    void Start () {
		Time.timeScale = 1;
        maxHealth = health;
        map = GameObject.FindGameObjectWithTag("Map");
        map.transform.localScale = new Vector3(mapSize,1,mapSize);
        gold += startingGoldAmount;
	}
	
	// Update is called once per frame
	void Update () {
        healthRatio = health / maxHealth;
        AddGain(gainAmount);
        Cheat();
        RemoveHealth(0);
	}
    //adds gold every second
    public void AddGain(int amount)
    {
        if(timer >= gainRate)
        {
            gold += amount;
            //Updating Ui gold so that gold amount cannot be changed
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

    //Handles damage done to the player
    public void RemoveHealth(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            health = 0;
            Time.timeScale = 0;
            Instantiate(gameOverScreen);
        }
    }

    //retrives the health ratio of the player
    public float GetHealthRatio()
    {
        return healthRatio;
    }

    //Allows a developer to increase thier gold amoun for testing
    void Cheat()
    {
        if(Input.GetKey("p") && Input.GetKey("l") && Input.GetKey("h"))
        {
            AddGold(500);
        }

    }
}
