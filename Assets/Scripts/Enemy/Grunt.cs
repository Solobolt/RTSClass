using UnityEngine;
using System.Collections;
using System;

public class Grunt : Enemy
{
    private int goldWorth = 1;
    public override void splitUp()
    {
        gameController.AddGold(goldWorth);
    }
}
