using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {


	private Transform myTransform;
	
    //holds enemy variables
	private GameObject[] enemies;
	private GameObject closetsEnemy;
	private float currentDistance;

    //Projectile Variables
	private float moveSpeed = 10;
	private int damage = 10;
    private float radius = 5.0f;

    //Timer Variables
	private float updraftTimer;
	private float updraftDelay = 2.0f;

	GameController gameController;

    //Calls on start
	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		myTransform = this.transform;
	}
	
    //Calls every Frame
	void Update ()
	{
        //If there are no enemies, explode
		GetEnemies();
		if (closetsEnemy != null) {
			TargetEnemy ();
			Move ();
		} 
		else 
		{
            explotion();
        }
	}

    //Makes the palyer move
	void Move()
	{
        //During the timer head upwards 
		if (updraftTimer < updraftDelay) 
		{
			Vector3 currentPos = myTransform.position;
			currentPos.y += (moveSpeed) * Time.deltaTime;
			myTransform.position = currentPos;
		} 
		else //when the timer is finnished turn and attack the nearest enemy
		{
			myTransform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		}
		updraftTimer += Time.deltaTime;
	}
	
	//Finds All enemies within the scene
	void  GetEnemies()
	{
		enemies = gameController.enemies.ToArray();
		for(int i = 0; i < enemies.Length; i++)
		{
			float distance = Vector3.Distance(myTransform.position, enemies[i].gameObject.transform.position);
			
			if(closetsEnemy != null)
			{
				currentDistance = Vector3.Distance(myTransform.position, closetsEnemy.gameObject.transform.position);
			}
			else
			{
				currentDistance = 1000.0f;
			}
			
			if(distance < currentDistance)
			{
				currentDistance = distance;
				closetsEnemy = enemies[i];
			}
		}
	}
	
	//turns the weapon barrel to face the nearest enemy
	void TargetEnemy()
	{
		if (closetsEnemy != null)
		{
			Vector3 target = closetsEnemy.transform.position - myTransform.position;
			myTransform.rotation = Quaternion.LookRotation(target);
		}
	}

	//HAndles expltions
	void explotion()
	{
		enemies = gameController.enemies.ToArray();
		for(int i = 0; i < enemies.Length; i++)
		{
			float distance = Vector3.Distance(myTransform.position, enemies[i].gameObject.transform.position);
			
			if(distance <= radius)
			{
				enemies[i].GetComponent<Enemy>().RemoveHealth(damage);
			}
		}
		
		Destroy (this.gameObject);
	}

	//handles Impact
	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.tag == "Enemy")
		{
			explotion();
		}
	}
}
