using UnityEngine;
using System.Collections;
using System;

public class Tank : Enemy {

    public GameObject wagon;
    private int goldWorth = 10;
    private int spawnNum = 3;

    //If the enemy dies it breaks up into bits
    public override void splitUp()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            Instantiate(wagon, myTransform.position, myTransform.rotation);
        }
        gameController.AddGold(goldWorth);
    }
}
