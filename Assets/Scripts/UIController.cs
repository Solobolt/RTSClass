﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {    
    private SelectionMovement selectionMovement;
    private GameController gameController;
    public GameObject[] towers;
    public Text uiGold;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        selectionMovement = GameObject.FindGameObjectWithTag("GameController").GetComponent<SelectionMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        uiGold.text = "GOLD:" + gameController.UIGold;
	}



    //creates a selected tower
    public void Tower(int towerNumb)
    { 

        if(towerNumb < towers.Length)
        {
            if(towers[towerNumb].GetComponent<Tower>().cost <= gameController.UIGold)
            {
                selectionMovement.CreateTower(towers[towerNumb]);
            }
            else
            {
                print("Not Enough Gold");
            }
        }
        else
        {
            print("ERROR: UIController Tower - no tower in array");
        }
    }
}