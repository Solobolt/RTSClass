using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Enemy : MonoBehaviour {

    public int health = 1;

    //public GameObject[] travelPoints;
    private GameObject endPosition;

    private Transform myTransform;
    private GameController gameController;

    //A* Navigation
    private NavMeshAgent agent;
    private int moveSpeed;
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
        if(health <= 0)
        {
            gameController.enemies.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
