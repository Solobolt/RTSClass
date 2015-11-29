using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    public int health = 1;

    public GameObject[] travelPoints;

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
        myTransform = this.transform;
        agent = GetComponent<NavMeshAgent>();
        movePostion = myTransform.position;

        gameController.enemyCount++;
    }

    // Update is called once per frame
    void Update()
    {
        //Move unit
        agent.SetDestination(movePostion);
        Debug.DrawLine(myTransform.position, movePostion, Color.white);
    }

    //Changes the units destination
    public void Move(Vector3 newMovePosition)
    {
        movePostion = newMovePosition;
    }
}
