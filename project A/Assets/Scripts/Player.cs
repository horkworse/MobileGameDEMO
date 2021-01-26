using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity = 50f;
    public FloatingJoystick joystick;
    public FloatingJoystick joystick_1;

    private float rotationY;
    private CharacterController ch;
    private Vector3 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Vector3.zero;
        moveInput.z = joystick.Vertical * velocity;
        moveInput.x = joystick.Horizontal * velocity;
        moveInput.y = -10f;
        ch.Move(moveInput * Time.deltaTime);

        rotationY = Mathf.Atan2(joystick_1.Direction.x, joystick_1.Direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
               
    }
}
