using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creep : Character
{
    public Transform goal;
    public NavMeshAgent agent;
    public static bool speed_change = false;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        // Смерть крипа
        if (HP <= 0) Destroy(gameObject);
        // Следование на позицию цели
        if (HP > 0)
        agent.destination = goal.position;
        if (speed_change == true)
        {
            agent.speed = 0;
            speed_change = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Bullet")
        {
            HP -= AmmoShot.bulletDamage;
        }
        if (other.gameObject.tag is "Slow_Area")
        {
            Debug.Log("Creep slow");
            agent.speed *= 0.5f;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag is "Slow_Area")
        {
            agent.speed *= 2f;
        }
    }
}


//</NavMeshAgent>