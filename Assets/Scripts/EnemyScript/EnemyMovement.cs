using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    protected Transform player;
    protected NavMeshAgent nav;
    protected Animator anim;
    protected EnemyAttack enemyat;
    protected EnemyHealth enemyhe;

    private PlayerHealth playerhe;


    private float MaxDistance = 2.70f;
    [SerializeField] public Slider lifeBar;
    private bool isDead=false;
    
    protected void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character1").transform;
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        enemyhe = GetComponent<EnemyHealth>();
        playerhe = GameObject.FindGameObjectWithTag("Character1").GetComponent<PlayerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= MaxDistance && !isDead){
           // Debug.Log("AGENT, STOP IT NOW");
           // Debug.Log(Vector3.Distance(transform.position, player.position));
            nav.isStopped = true;
            nav.velocity = Vector3.zero;
            anim.enabled = false;
        }
        else if (!isDead)
        {
            nav.isStopped = false;
            anim.enabled = true;
        }


        lifeBar.transform.LookAt(Camera.main.transform.position);  

        if (!isDead && playerhe.getCurrentH() > 0 && enemyhe.getCurrent() > 0)
        { 
                nav.SetDestination(player.position);
                //Debug.Log("Mi muovo");
     
        }
        else if(playerhe.getCurrentH() <= 0 && !isDead) { // Non entra
           // Time.timeScale = 0;
            nav.enabled = false;
            anim.SetTrigger("PlayerDead");
            Debug.Log("Trigger");
            enabled = false;
        }
    }



    public void setDeath()
    {
        isDead = true;
    }


}
