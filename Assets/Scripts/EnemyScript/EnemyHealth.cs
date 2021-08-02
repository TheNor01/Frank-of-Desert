using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour, Ikillable<int>
{

    protected float startingHealth;
    protected int multi;
    protected float currentHealth;
    protected bool isDead;
    protected int scoreValue;
    protected float enemyType;
    public Slider healthSlider;

    [SerializeField] GameObject effect;
    protected NavMeshAgent nav;

    protected Animator anim;
    protected SphereCollider sphereCollider;
    protected EnemyMovement movScript;
    //EnemyStatus enemyStatus;


    // Start is called before the first frame update
    protected void Awake()
    {
        getAll();
        multi = PlayerPrefs.GetInt("Diff");
        //multi = multi / 2;
      
        //Debug.Log(startingHealth);
    }

    void Start()
    {
        initHealth();
    }

   

    void getAll()
    {
        anim = GetComponent<Animator>();
        sphereCollider = GetComponent<SphereCollider>();
        movScript = GetComponent<EnemyMovement>();
        //enemyStatus = GetComponent<EnemyStatus>();
        nav = GetComponent<NavMeshAgent>();
    }


    void initHealth()
    {
        startingHealth = 100 * multi * enemyType;
        Debug.Log(startingHealth);
        currentHealth = startingHealth;
        healthSlider.value = startingHealth;
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;


        //print("BASE " + currentHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fireball")
        {
            Debug.Log("Colpito dalla fire");

            if (isDead) return;
            int value = CalculateDamage(other);
            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
            TakeDamage(value);
        }
    }

    private int CalculateDamage(Collider other)
    {
        int value;
        value = other.GetComponent<Fireball>().getBaseDamage();
        Debug.Log("Danno subito" + value);
        return value;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
    }


    public void Death()
    {
        if (!isDead)
        {
            DisableAll();  
        }
    }

    //protected void updateScore() { }


    private void DisableAll()
    {
        isDead = true;
        nav.enabled = false;
        movScript.enabled = false;
        Debug.Log("disable");
        anim.SetTrigger("Dead");
        sphereCollider.isTrigger = true;
    }

    void callDeath()
    {
         Destroy(gameObject);
       // gameObject.SetActive(false);
        gameObject.layer = 15;
    }

    void spawnEffect()
    {
        Instantiate(effect, transform.position, transform.rotation);
    }

    public bool getDead()
    {
        return isDead;
    }

    public float getCurrent()
    {
        return currentHealth;
    }

}
