using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;
    Rigidbody rb;
    public bool playerInRange;
    float timer;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Character1");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("Range");
            playerInRange = true;
           // rb.velocity = Vector3.zero;
 
     
          
        }   
    }


   void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
       {
            Debug.Log("RangeExit");
            playerInRange = false;
            nav.isStopped = false;
            anim.enabled = true;
            //anim.SetBool("In Range", false);
        }
  }





    // Update is called once per frame
    void Update()
    { 

        timer += Time.deltaTime;
        if( timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
           // Debug.Log("Attacco");
            Attack();
            //anim.ResetTrigger("Attack");

        }
        
        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        
        }
    }
}
