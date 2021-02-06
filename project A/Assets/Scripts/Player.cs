using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public FloatingJoystick joystick;
    
    
    private CharacterController ch;
    private Vector3 moveInput;

    public static float hpChange;
    //public static float normalSpeed;
    public static float objectSpeed;
    void Start()
    {
        ch = GetComponent<CharacterController>();
        hpChange = HP;
        //normalSpeed = Speed;
        objectSpeed = Speed;
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
        moveInput.z = joystick.Vertical * objectSpeed;

        moveInput.x = joystick.Horizontal * objectSpeed;
        moveInput.y = -5f;
        ch.Move(moveInput * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Enemy") {
            Debug.Log("ENTERED");
        }
    }
}
