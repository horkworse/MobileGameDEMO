using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedCreep : Character
{
    public Transform goal;
    public NavMeshAgent agent;
    public static bool speed_change = false;

    public float sightRange;
    public bool playerInSightRange;
    public float rangeToPlayer;
    public float agroRange;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    bool walkPointSet;
    public float walkPointRange;

    public Vector3 walkPoint;

    public float time;


    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = Speed;
        //Instantiate(CreepWeapon, GunPoint.position, GunPoint.rotation, GunPoint.transform);
    }

    void Update(){

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        rangeToPlayer = Vector3.Distance(goal.position, transform.position);

        if (playerInSightRange && HP > 0) MoveToPlayer();
        else if (!playerInSightRange) Patrolling();
        if (HP <= 0) Destroy(gameObject);
        if (speed_change == true)
        {
            agent.speed = 0;
            speed_change = false;
        }
    }

    void Patrolling()
    {
        if (time > 2f)
        {
            walkPoint = FindPoint();
            time = 0;
        }
        else time += Time.deltaTime;

        agent.SetDestination(walkPoint);
    }

    Vector3 FindPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        // сделать проверку на стену (?)

        return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    }

    void MoveToPlayer()
    {
        if (rangeToPlayer > agroRange){
            agent.destination = transform.position + Vector3.MoveTowards(agent.destination, goal.position, 3f);
        }
        else{
            agent.destination = goal.position - Vector3.MoveTowards(agent.destination, goal.position, 3f);
        }
    }

    void Shoot()
    {
        
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
        if (other.gameObject.tag is "ActionArea")
        {
            //agent.speed = 0f;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag is "Slow_Area")
        {
            agent.speed *= 2f;
        }
        if (other.gameObject.tag is "ActionArea")
        {
            //agent.speed = Speed;
        }
    }
}