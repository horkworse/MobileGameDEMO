using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShot : AmmoType
{
    private float time = 0;
    public static float bulletDamage;
    void Start()
    {
        bulletDamage = Damage;
    }


    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        if (time > Range)
        {
            Destroy(gameObject);
            time = 0;
        }
        else
            time += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Enemy" || other.gameObject.tag is "Wall") Destroy(gameObject);
    }
}