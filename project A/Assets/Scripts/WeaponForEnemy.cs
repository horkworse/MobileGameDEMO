using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponForEnemy : Weapon
{
    public Transform Shot_point;
    private float time;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            if (RangedCreep.gunRangeFire)
            {
                Instantiate(AmmoType, Shot_point.position, Shot_point.rotation);
                time = RateOfFire;
            }
        }
        else
            time -= Time.deltaTime;
    }
}
