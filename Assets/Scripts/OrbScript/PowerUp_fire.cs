using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_fire : MonoBehaviour
{
    public float multiplier = 5f;
    GameObject staff;
    private float x;

    private void Awake()
    {
        staff = GameObject.FindGameObjectWithTag("Staff");
    }

    // public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character1"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        // Instantiate(pickupEffect, transform.position, transform.rotation);
        Debug.Log("Picked up PW_fire");
       // x = staff.GetComponent<Staff>().timeToSpawn;
        Debug.Log("Value " + x);
        staff.GetComponent<Staff>().timeToSpawn += multiplier;

        gameObject.SetActive(false);
        GetComponent<Collider>().enabled = false;
        

        yield return new WaitForSeconds(3);


        staff.GetComponent<Staff>().timeToSpawn /= multiplier;
        //player.transform.localScale /= multiplier;
        Debug.Log("descale");
        Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}