using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShot : AmmoType
{

    void Start()
    {
        
    }


    void Update()
    {
        transform.Translate(Vector3.forward * 5f * Time.deltaTime);
    }
}
