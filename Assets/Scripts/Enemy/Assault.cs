using UnityEngine;
using System.Collections;

public class Assault : Enemy {

	public GameObject tank;
	private int goldWorth = 5;
	private int spawnNum = 5;

    //If the enemy dies it breaks up into bits
    public override void splitUp()
	{
		for (int i = 0; i < spawnNum; i++)
		{
			Instantiate(tank, myTransform.position, myTransform.rotation);
		}
        gameController.AddGold(goldWorth);
    }
}
