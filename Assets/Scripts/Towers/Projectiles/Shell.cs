using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {

	private Transform myTransform;
	
	private GameObject[] enemies;
	private GameObject closetsEnemy;
	private float currentDistance;

	private float moveSpeed = 10;
	private int damage = 10;

	private float updraftTimer;
	private float updraftDelay = 2.0f;

	GameController gameController;

	private float radius = 5.0f;
	
	void Start ()
	{
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		myTransform = this.transform;
	}
	
	void Update ()
	{
		GetEnemies();
		if (closetsEnemy != null) {
			TargetEnemy ();
			Move ();
		} 
		else 
		{
			myTransform.Translate (Vector3.down * moveSpeed * Time.deltaTime);
			if(myTransform.position.y <= (0.3f))
			{
				explotion();
			}
		}
	}

	void Move()
	{
		if (updraftTimer < updraftDelay) 
		{
			Vector3 currentPos = myTransform.position;
			currentPos.y += (moveSpeed) * Time.deltaTime;
			myTransform.position = currentPos;
		} 
		else 
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
