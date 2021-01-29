using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    //public float velocity = 50f;
    public FloatingJoystick joystick;
    
    
    private float rotationY;
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
        moveInput.y = 0f;
        ch.Move(moveInput * Time.deltaTime);

    }
}
