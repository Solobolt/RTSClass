using UnityEngine;
using System.Collections;

public class PlayerUnit : MonoBehaviour {

	private Transform myTransform;

	//A* Navigation
	private NavMeshAgent agent;
	private int moveSpeed;
	private Vector3 movePostion;

	// Use this for initialization
	void Start () {
		myTransform = this.transform;
		agent = GetComponent<NavMeshAgent> ();
		movePostion = myTransform.position;
	}
	
	// Update is called once per frame
	void Update () {
	//Move unit
		agent.SetDestination (movePostion);
		Debug.DrawLine (myTransform.position,movePostion,Color.white);
	}

	//Changes the units destination
	public void Move(Vector3 newMovePosition)
	{
		movePostion = newMovePosition;
	}
}
