using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    public FloatingJoystick joystick;
    public static int amount = 0;
    
    private CharacterController ch;
    private Vector3 moveInput;

    public static float hpChange;
    void Start()
    {
        amount = 0;
        ch = GetComponent<CharacterController>();
        hpChange = HP;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy")) amount += 1;
    }

    void Update()
    {
        if (hpChange < 200f)
            hpChange += Regen;

        if (hpChange <= 0f)
        {
            SceneManager.LoadScene(3);
        }


        moveInput = Vector3.zero;
        moveInput.z = joystick.Vertical * Speed;

        moveInput.x = joystick.Horizontal * Speed;
        moveInput.y = -5f;
        ch.Move(moveInput * Time.deltaTime);
        if (GameObject.FindGameObjectWithTag("Enemy") is null)
        {
            SceneManager.LoadScene(0);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Slow_Area")
        {
            Speed *= 0.5f;
        }
        if (other.gameObject.tag is "Damage_Zone")
        {
            StartCoroutine("Hit");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("123");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag is "Slow_Area")
        {
            Speed *= 2f;
        }
        if (other.gameObject.tag is "Damage_Zone")
        {
            StopCoroutine("Hit");
        }
    }

    IEnumerator Hit(){
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            hpChange -= 1;
            yield return new WaitForSeconds(1f);
        }
    }
}
