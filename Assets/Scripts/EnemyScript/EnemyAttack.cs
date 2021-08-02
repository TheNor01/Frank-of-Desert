using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    protected float timeBetweenAttacks;
    protected int attackDamage;

    Animator anim;
    GameObject player;


    protected PlayerHealth playerHealth;
    protected EnemyHealth enemyHealth;


    NavMeshAgent nav;
    public bool playerInRange;
    protected float timer;
    

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Character1");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<NavMeshAgent>();
    }

    void OnTriggerStay(Collider other){
        if (other.gameObject == player)
        {
            Debug.Log("Range");
            playerInRange = true;
        }   
    }


   void OnTriggerExit(Collider other){
        if (other.gameObject == player)
       {
            Debug.Log("RangeExit");
            playerInRange = false;
            if(!enemyHealth.getDead() || player.GetComponent<PlayerHealth>().getCurrentH() <=0) nav.isStopped = false;
            anim.enabled = true;
        }
    }

    void Update()
    {
        prepareAttack();
    }

   

    protected virtual void prepareAttack()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.getCurrent() > 0)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        timer = 0f;
        if (playerHealth.getCurrentH() > 0)
        {
            playerHealth.TakeDamage(10);

        }
    }
}
