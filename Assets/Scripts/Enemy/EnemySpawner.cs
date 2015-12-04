using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float gameTimer = 0;

    private float spawnTimer;
    private int waveNumber = 0;
    public float spawnRate = 5.0f;

    public GameObject EnemyGrunt;
    public GameObject startPostion;

	// Use this for initialization
	void Start ()
    {
        spawnTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        WaveTimer();

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            spawnEnemy();
            spawnTimer = 0;
        }
        
	}

    //Creates a set of enemies set to the timer
    void spawnEnemy()
    {
        Instantiate(EnemyGrunt,startPostion.transform.position,startPostion.transform.rotation);
    }

    void WaveTimer()
    {
        gameTimer += Time.deltaTime;
    }
}
