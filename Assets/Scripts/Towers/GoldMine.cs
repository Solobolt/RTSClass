using UnityEngine;
using System.Collections;
using System;

public class GoldMine : Tower {

    private int extraGain = 2;

    public override void StartTowerEffect()
    {
        
    }

    public override void UpdateTowerEffect()
    {
        //add 2 gold everys second
        gameController.AddGain(extraGain);
    }
}
