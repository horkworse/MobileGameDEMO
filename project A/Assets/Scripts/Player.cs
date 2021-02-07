using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public FloatingJoystick joystick;
    
    
    private CharacterController ch;
    private Vector3 moveInput;

    public static float hpChange;
    void Start()
    {
        ch = GetComponent<CharacterController>();
        hpChange = HP;
    }

    void Update()
    {
        if (hpChange < 200f)
            hpChange += Regen;

        if (hpChange <= 0f)
        {
            Destroy(gameObject);
        }


        moveInput = Vector3.zero;
        moveInput.z = joystick.Vertical * Speed;

        moveInput.x = joystick.Horizontal * Speed;
        moveInput.y = -5f;
        ch.Move(moveInput * Time.deltaTime);

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Slow_Area")
        {
            Speed *= 0.5f;
        }
        if (other.gameObject.tag is "Damage_Zone")
        {
            hpChange -= 1;
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
    }
}
