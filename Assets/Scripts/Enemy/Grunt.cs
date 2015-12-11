using UnityEngine;
using System.Collections;
using System;

public class Grunt : Enemy
{
    private int goldWorth = 1;
    
    //adds gold for kiling the enemy
    public override void splitUp()
    {
        gameController.AddGold(goldWorth);
    }
}
