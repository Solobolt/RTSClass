using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {    
    private SelectionMovement selectionMovement;
    private GameController gameController;
    public GameObject[] towers;
    public Text uiGold;
    public Text uiWaveTimer;
    private bool fastForward = false;

    public Slider uiHealthSlider;

    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        selectionMovement = GameObject.FindGameObjectWithTag("GameController").GetComponent<SelectionMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        GoldUIUpdate();
        uiHealthSlider.value = gameController.GetHealthRatio();
	}

    //Sets the Gold UI and limmits the size to prevent over flow of money
    void GoldUIUpdate()
    {
        int currentGold = gameController.UIGold;
        if (gameController.UIGold > 999999)
        {
            currentGold = 999999;
        }
        uiGold.text = "GOLD:" + currentGold;
    }

    //Sets the wave timer
    public void SetWaveTimer(float timer)
    {
        if(timer > 0)
        {
            uiWaveTimer.enabled=true;
            float seconds = Mathf.Floor(timer);
            float miliSeconds = Mathf.Floor((timer - seconds) * 100.0f);

            uiWaveTimer.text = ">>> " + seconds + ":" + miliSeconds + " <<<";
        }
        else
        {
            uiWaveTimer.text = "";
            uiWaveTimer.enabled = false;
        }
    }

    //Fast Forward toggle
    public void toggleFastForward()
    {
        if(fastForward == false)
        {
            fastForward = true;
            Time.timeScale = 5;
        }
        else
        {
            if (fastForward == true)
            {
                fastForward = false;
                Time.timeScale = 1;
            }
        }
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
