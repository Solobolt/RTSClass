using UnityEngine;
using System.Collections;

public class Assault : Enemy {

	public GameObject tank;
	private int goldWorth = 5;
	private int spawnNum = 5;
	
	public override void splitUp()
	{
		for (int i = 0; i < spawnNum; i++)
		{
			gameController.AddGold(goldWorth);
			Instantiate(tank, myTransform.position, myTransform.rotation);
		}
		
	}
}
