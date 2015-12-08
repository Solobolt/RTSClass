using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour {

    public int health = 1;

    //public GameObject[] travelPoints;
    private GameObject endPosition;

    public Transform myTransform;
    public GameController gameController;

    //A* Navigation
    private NavMeshAgent agent;
    private float moveSpeed = 100;
    private Vector3 movePostion;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        endPosition = GameObject.FindGameObjectWithTag("EndPoint");
        myTransform = this.transform;
        agent = GetComponent<NavMeshAgent>();
        movePostion = myTransform.position;

        gameController.enemies.Add(this.gameObject);
        gameController.enemyCount++;
    }

    // Update is called once per frame
    void Update()
    {
        //Move unit
        agent.SetDestination(movePostion);
        Debug.DrawLine(myTransform.position, movePostion, Color.white);
        //Move(travelPoints[1].transform.position);
        Move(endPosition.transform.position);

        //Checks to see if thr enemy has reached its destination
        if(Mathf.Floor(myTransform.position.x) + 0.5 == Mathf.Floor( endPosition.transform.position.x ) +0.5 && Mathf.Floor(myTransform.position.z) + 0.5 == Mathf.Floor(endPosition.transform.position.z) + 0.5)
        {
            gameController.health -= health;
            gameController.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }

		HealthCheck ();
    }

    //Changes the units destination
    public void Move(Vector3 newMovePosition)
    {
        movePostion = newMovePosition;
    }

    //Removes health from the enemy and checks if it is dead
    public void RemoveHealth(int amount)
    {
        health -= amount;
    }

	void HealthCheck()
	{
		if(health <= 0)
		{
			gameController.enemies.Remove(this.gameObject);
			Destroy(this.gameObject);
			splitUp();
		}
	}

    //what happens on death
    public abstract void splitUp();
}
