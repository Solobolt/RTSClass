using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {    
    private SelectionMovement selectionMovement;
    public GameObject[] towers;

    // Use this for initialization
    void Start () {
        selectionMovement = GameObject.FindGameObjectWithTag("GameController").GetComponent<SelectionMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //creates a selected tower
    public void Tower(int towerNumb)
    {
        if(towerNumb < towers.Length)
        {
            selectionMovement.CreateTower(towers[towerNumb]);
        }
        else
        {
            print("ERROR: UIController Tower - no tower in array");
        }
    }
}
