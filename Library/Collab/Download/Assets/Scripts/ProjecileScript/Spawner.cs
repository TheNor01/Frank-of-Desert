using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]  public GameObject projectile;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject fireball = Instantiate(projectile, transform) as GameObject;
            Rigidbody rd = fireball.GetComponent<Rigidbody>();
            rd.velocity = transform.forward * 30;

        }
    }
}
