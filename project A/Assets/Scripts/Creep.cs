using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Creep : Character
{
    public Transform goal;
    public NavMeshAgent agent;
    public static bool speed_change = false;

    public float sightRange;
    public bool playerInSightRange;

    public LayerMask whatIsPlayer;
    public LayerMask whatIsGround;

    public bool walkPointSet;
    public float walkPointRange;

    Vector3 walkPoint;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){

        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);


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
        // не удалять, доделает hork

        if (!walkPointSet) SearchWalkPoint();

        if (!walkPointSet) agent.SetDestination(walkPoint);

        var distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        // не удалять, доделает hork
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    void MoveToPlayer()
    {
        agent.destination = goal.position;
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