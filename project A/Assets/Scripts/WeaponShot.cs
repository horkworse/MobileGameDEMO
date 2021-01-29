using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : Weapon

{

    public Transform Shot_point;
    private float time;
    void Start()
    {

    }

    void Update()
    {
        if (time <= 0)
        {
            if (Head.IsAllowedToShoot == true)
            {
                Instantiate(AmmoType, Shot_point.position, Shot_point.rotation);
                time = RateOfFire;


            }
        }
        else
            time -= Time.deltaTime;




    }
}
