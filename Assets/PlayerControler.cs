using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float acceleration = 10;
    public GameObject bulletPrefab;

    private Rigidbody rb;
    private Vector2 controlls;

    private Transform GunLeft, GunRight;
    private bool fireButtonDown = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GunLeft = transform.Find("GunLeft");
        GunRight = transform.Find("GunRight");
    }

    // Update is called once per frame
    void Update()
    {
        float v, h;
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");
        controlls = new Vector2(h, v);

        if(Math.Abs(transform.position.x) > 19)
        {
            Vector3 newPosition = new Vector3(transform.position.x * -1, 0, transform.position.z);
            transform.position = newPosition;
        }
        if (Math.Abs(transform.position.z) > 9)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 0, transform.position.z * -1);
            transform.position = newPosition;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireButtonDown= true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * controlls.y * acceleration, ForceMode.Acceleration);
        rb.AddTorque(transform.up * controlls.x * acceleration, ForceMode.Acceleration);
        if (fireButtonDown)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, GunLeft.position, Quaternion.identity);
            bullet1.transform.parent = null;
            bullet1.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.VelocityChange);
            Destroy(bullet1, 5);

            GameObject bullet2 = Instantiate(bulletPrefab, GunRight.position, Quaternion.identity);
            bullet2.transform.parent = null;
            bullet2.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.VelocityChange);
            Destroy(bullet2, 5);

            fireButtonDown= false;    
        }
    }
}