using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private float damage = 10f;
    private float attackDelay = 1f;
    private float time = 0;
    public GameObject player;

    private CharacterController ch;
    private Vector3 moveVector;

    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Player.hpChange <= 0) Destroy(gameObject);
        if (HP <= 0) Destroy(gameObject);
        if (HP < 200f) HP += Regen;
        Move();
        if (HP <= 0) Die();
    }

    void Attack()
    {
        if (Player.hpChange > 0)
        {
            Player.hpChange -= damage;
            Debug.Log(Player.hpChange);
        }
        else
        {
            //??
            return;
        }
    }

    private void Move()
    {
        if (time > attackDelay)
        {
            if (transform.position == player.transform.position)
            {
                // stop and atack
                Attack();
                time = 0;
            }
            else
            {
                moveVector.x = player.transform.position.x - transform.position.x;
                moveVector.z = player.transform.position.z - transform.position.z;
                moveVector.y = -5f;
                // move to player
                ch.Move(moveVector * Time.deltaTime);
            }
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    void Die()
    {
        //enemy is destroing
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Bullet")
        {
            HP -= AmmoShot.bulletDamage;
        }
    }
}




