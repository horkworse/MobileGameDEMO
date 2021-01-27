using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character
{
    public float velocity = 50f;
    public FloatingJoystick joystick;
    
    
    private float rotationY;
    private CharacterController ch;
    private Vector3 moveInput;

    public static float hpChange;
    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame 

    void Update()
    {
        if (HP < 200f)
            HP += Regen;
        hpChange = HP;

        moveInput = Vector3.zero;
        moveInput.z = joystick.Vertical * velocity;

        moveInput.x = joystick.Horizontal * velocity;
        moveInput.y = 0f;
        ch.Move(moveInput * Time.deltaTime);

    }
}
