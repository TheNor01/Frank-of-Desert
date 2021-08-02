using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{

    GameObject staff;
    
    //public float timeBtFire = 0.15f;
    public float range= Mathf.Infinity;

    Ray shootRay;
    RaycastHit shootHit;
    LineRenderer gunLine;
    GameObject spawner;
    Transform spawnPos;
  



    // Start is called before the first frame update
    void Awake()
    {
        staff = GameObject.FindGameObjectWithTag("Staff");
        
        spawner = GameObject.FindGameObjectWithTag("SpawnFire");
        gunLine = spawner.GetComponent<LineRenderer>();
        spawnPos = spawner.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void callShoot()
    {
        staff.GetComponent<Staff>().StartCoroutine("Shoot");
        SoundManager.instance.PlayPlayerAttack();

     }
}
