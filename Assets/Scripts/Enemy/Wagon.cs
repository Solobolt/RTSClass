using UnityEngine;
using System.Collections;
using System;

public class Wagon : Enemy {
    public GameObject grunt;
    private int goldWorth = 5;
    private int spawnNum = 2;

    //If the enemy dies it breaks up into bits
    public override void splitUp()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            Instantiate(grunt, myTransform.position, myTransform.rotation);
        }
        gameController.AddGold(goldWorth);
    }
}
