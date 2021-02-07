using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Head : MonoBehaviour
{
    public Transform GunPoint;
    public GameObject Creep_Weapon;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Creep_Weapon, GunPoint.position, GunPoint.rotation, GunPoint.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
