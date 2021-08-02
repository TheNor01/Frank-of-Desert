using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField] public GameObject weapon;
    [SerializeField] public GameObject shield;

    Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character1").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
