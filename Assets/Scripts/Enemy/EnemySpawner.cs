using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float gameTimer = 0;

    private float spawnTimer;
    public float spawnRate = 1.0f;
    private float waveDelay = 10.0f;

    private int waveNumber = 1;

    private int gruntNum = 5;
    private int wagonNum = 0;
    private int tankNum = 0;

    public GameObject EnemyGrunt;
    public GameObject EnemyWagon;


    public GameObject startPostion;

	// Use this for initialization
	void Start ()
    {
        spawnTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        waveDelay -= Time.deltaTime;

        if(waveDelay <= 0)
        {
            waveDelay = 0;
            spawnTimer += Time.deltaTime;
            SpawnEnemy();
        }
        

    }

    //handles how long the game has been going
    void WaveCheck()
    {
        switch (waveNumber)
        {
            case 1:
                SetEnemyNumbers(5, 0, 0);
                break;

            case 2:
                SetEnemyNumbers(10, 1, 0);
                break;

            case 3:
                SetEnemyNumbers(1, 5, 0);
                break;

            default:
                break;
        }
    }

    void SetEnemyNumbers(int grunts,int wagons, int tanks)
    {
        gruntNum = grunts;
        wagonNum = wagons;
        tankNum = tanks;
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
                        //Instantiate(EnemyTank, startPostion.transform.position, startPostion.transform.rotation);
                        tankNum--;
                    }
                    else
                    {
                        waveNumber++;
                        WaveCheck();
                        waveDelay = 10.0f;
                    }
                }
            }
            spawnTimer = 0;
        }
    }
}
