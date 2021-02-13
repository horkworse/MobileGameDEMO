using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShot : Weapon
{
    public Transform Shot_point;
    private float time;
    public static int AmmoAmount;

    void Start()
    {
        AmmoAmount = startAmmo;
    }

    void Update()
    {
        if (time <= 0)
        {
            if (Head.IsAllowedToShoot == true && AmmoAmount > 0)
            {
                AmmoAmount -= 1;
                Instantiate(AmmoType, Shot_point.position, Shot_point.rotation);
                time = RateOfFire;
            }
        }
        else
            time -= Time.deltaTime;
    }
}
