using UnityEngine;
using System.Collections;

public class Morter : Tower {

	private Transform myTransform;
	public GameObject projectile;
	private float fireRate = 5.0f;
	private float fireTime;
	private float range = 100f;
	
	private GameObject[] enemies;
	private GameObject closetsEnemy;
	private float currentDistance;
	
	public override void StartTowerEffect()
	{
		myTransform = this.transform;
	}
	
	public override void UpdateTowerEffect()
	{
		GetEnemies();
		if (closetsEnemy != null)
		{
			if (currentDistance <= range)
			{
				TargetEnemy();
				fireProjectile();
			}
		}
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
	
	void fireProjectile()
	{
		if(fireTime>= fireRate)
		{
			GameObject bullet = Instantiate(projectile, myTransform.position, Quaternion.Euler(0,0,0))as GameObject;
			fireTime = 0;
		}
		fireTime += Time.deltaTime;
	}
	
	//turns the weapon barrel to face the nearest enemy
	void TargetEnemy()
	{
		if (closetsEnemy != null)
		{
			Vector3 target = closetsEnemy.transform.position - myTransform.position;
		}
	}
}
