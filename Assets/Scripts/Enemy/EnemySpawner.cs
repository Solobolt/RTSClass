using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private UIController uiController;

    private float gameTimer = 0;

    private float spawnTimer;
    public float spawnRate = 1.0f;
    private float waveDelay = 10.0f;

    private int waveNumber = 1;
    private bool noMoreWaves = false;
    public bool freePlayMode = false;

    private int gruntNum = 5;
    private int wagonNum = 0;
    private int tankNum = 0;
	private int assaultNum= 0;

    public GameObject EnemyGrunt;
    public GameObject EnemyWagon;
    public GameObject EnemyTank;
	public GameObject EnemyAssault;


    public GameObject startPostion;

	// Use this for initialization
	void Start ()
    {
        uiController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
        spawnTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(noMoreWaves == false)
        {
            waveDelay -= Time.deltaTime;
            uiController.SetWaveTimer(waveDelay);
            if (waveDelay <= 0)
            {
                waveDelay = 0;
                spawnTimer += Time.deltaTime;
                SpawnEnemy();
            }
        }
    }

    //handles how long the game has been going
    void WaveCheck()
    {
        switch (waveNumber)
        {
            case 1:
                SetEnemyNumbers(5, 0, 0, 0);
                break;

            case 2:
                SetEnemyNumbers(10, 1, 0, 0);
                break;

            case 3:
                SetEnemyNumbers(5, 2, 0, 0);
                break;

            case 4:
                SetEnemyNumbers(10, 4, 0, 0);
                break;

            case 5:
                SetEnemyNumbers(5, 6, 0, 0);
                break;

            case 6:
                SetEnemyNumbers(10, 0, 1, 0);
                break;

            case 7:
                SetEnemyNumbers(2, 1, 3, 1);
                break;

            default:
                if(freePlayMode == false)
                {
                    noMoreWaves = true;
                    print("YOU WIN");
                }
                else
                {
                    SetEnemyNumbers(1 + waveNumber, waveNumber * 2, waveNumber * 3,waveNumber);
                }
                
                break;
        }
    }

    void SetEnemyNumbers(int grunts,int wagons, int tanks, int assualts)
    {
        gruntNum = grunts;
        wagonNum = wagons;
        tankNum = tanks;
		assaultNum = assualts;
    }

    //Creates a set of enemies set to the timer
    void SpawnEnemy()
    {
        if (spawnTimer >= spawnRate)
        {
            if (gruntNum != 0)
            {
                Instantiate(EnemyGrunt, startPostion.transform.position, startPostion.transform.rotation);
                gruntNum--;
            }
            else
            {
                if (wagonNum != 0)
                {
                    Instantiate(EnemyWagon, startPostion.transform.position, startPostion.transform.rotation);
                    wagonNum--;
                }
                else
                {
                    if (tankNum != 0)
                    {
                        Instantiate(EnemyTank, startPostion.transform.position, startPostion.transform.rotation);
                        tankNum--;
                    }
                    else
                    {
						if(assaultNum != 0)
						{
							Instantiate(EnemyAssault, startPostion.transform.position, startPostion.transform.rotation);
							assaultNum--;
						}
						else
						{
	                        waveNumber++;
	                        WaveCheck();
	                        waveDelay = 10.0f;
						}
                    }
                }
            }
            spawnTimer = 0;
        }
    }
}
