using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float damage = 10f;
    private float attackDelay = 2f;
    private float time = 0;
    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Attack()
    {
        if (Player.hpChange > 0 )
        {
            // atacking
            Debug.Log("attack");
        }
        else
        {
            //GameOver();
            return;
        }
    }

    private void Move(){
        if(time > attackDelay){
            if(transform.position == player.transform.position)
            {
                // stop and atack
                Attack();
                time = 0;
            }
            else
            {
                // move to player
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Speed*Time.deltaTime);
            }
        }
        else
        {
            time+=Time.deltaTime;
        }
    }
}

