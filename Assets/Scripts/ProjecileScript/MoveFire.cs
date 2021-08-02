using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFire : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed = 10;
    private float xForce;
    private float zForce;

    private Vector3 force;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
   // private void FixedUpdate()
    //{
       // xForce = Input.GetAxis("Horizontal");
      //  zForce = Input.GetAxis("Vertical");

    //}



    void Update()
    {
        force = new Vector3(xForce, 0.0F, zForce);
        transform.position += transform.forward * (Time.deltaTime * speed);
       // rb.AddForce(transform.forward * speed * Time.deltaTime);
    }
}
