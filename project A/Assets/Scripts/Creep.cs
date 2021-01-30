using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creep : Character
{
    public Transform goal;
    public NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        // Смерть крипа
        if (HP <= 0) Destroy(gameObject);
        // Следование на позицию цели
        agent.destination = goal.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Bullet")
        {
            HP -= AmmoShot.bulletDamage;
        }
    }
}


//</NavMeshAgent>