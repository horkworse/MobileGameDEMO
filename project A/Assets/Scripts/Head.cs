using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public FloatingJoystick joystick_1;
    public GameObject Gun;
    private float rotationY;
    public static float rotation;
    public Transform GunPoint;
    public GameObject Ammo;
    private Transform AmmoPoint;

    void Start()
    {
        Instantiate(Gun, GunPoint.position, GunPoint.rotation, GunPoint.transform);
        //AmmoPoint = GunPoint;
        //AmmoPoint.transform.position += new Vector3(0, 0, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        rotationY = Mathf.Atan2(joystick_1.Direction.x, joystick_1.Direction.y) * Mathf.Rad2Deg;
        rotation = rotationY;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        if (Mathf.Abs(joystick_1.Direction.x) > 0.5 || Mathf.Abs(joystick_1.Direction.y) > 0.5) Instantiate(Ammo, GunPoint.position, GunPoint.rotation);
    }
}
