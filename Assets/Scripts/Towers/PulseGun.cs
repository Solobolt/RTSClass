using UnityEngine;
using System.Collections;
using System;

public class PulseGun : Tower {

    private Transform myTransform;
    public GameObject projectile;
    private float fireRate = 1.0f;
    private float fireTime;
    private float range = 3.0f;
    
    //holds the objects that determain the direction that the projectiles are fired
    public GameObject[] weaponBarrel;

    //The gun model
    public GameObject gun;

    //handles Tower start
    public override void StartTowerEffect()
    {
        myTransform = this.transform;
    }
    
    //handles tower updates
    public override void UpdateTowerEffect()
    {
        fireProjectile();       
    }

    //fires a projetile in the facing direction of each muzzle
    void fireProjectile()
    {
        if (fireTime >= fireRate)
        {
            for(int i =0; i < weaponBarrel.Length;i ++)
            {
                GameObject bullet = Instantiate(projectile, weaponBarrel[i].transform.position, weaponBarrel[i].transform.rotation) as GameObject;
                bullet.GetComponent<Bullet>().editRange(range);
            }
            fireTime = 0;
        }
        fireTime += Time.deltaTime;
    }

}
