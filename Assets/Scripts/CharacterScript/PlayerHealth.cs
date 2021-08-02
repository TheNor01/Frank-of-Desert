using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int startingHealth = 100;
    private int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 0.5f;
    public Color flashColour = new Color(1f, 0f, 0f,0.1f);

    Animator anim;
    AudioSource playerAudio;
    CharacterMovement charMov;
    [SerializeField] GameObject dtmenu;
    [SerializeField] GameObject winmenu;

    string myname;
    float timer;
    
    bool isDead;
    bool damaged;
    public bool Invincible = false;

    HighscoreTable table;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        charMov = GetComponent<CharacterMovement>();
        healthSlider.maxValue = startingHealth;
        healthSlider.value = startingHealth;
        currentHealth = startingHealth;
        table = GameObject.Find("HighscoreTable").GetComponent<HighscoreTable>();
        Debug.Log("Livello diff"+PlayerPrefs.GetInt("Diff"));
    }


    private void Update()
    {
        healthSlider.value = currentHealth;



        Debug.Log("Current player He" + currentHealth);
        
        if (damaged==true )
        {
            damageImage.color = flashColour;
        }
        else
        {
           damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage( int amount)
    {

        if (!Invincible)
        {
            damaged = true;
            Debug.Log("P1 Prende danno");
            currentHealth -= amount;
            
            playerAudio.Play();

            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
        }
    }


    void Death()
    {
        isDead = true;
        anim.SetTrigger("Die");
        SoundManager.instance.PlayDefeat();
        SoundManager.instance.volueMainDown();
        charMov.enabled = false;
        Time.timeScale = 0;
        dtmenu.SetActive(true);
    }

    public void sendToRanking()
    {
        if (dtmenu.activeInHierarchy)
        {
            Debug.Log("Prendo nome dalla morte");
            myname = dtmenu.gameObject.transform.GetChild(0).GetComponent<DeathMenu>().TakeName();
        }
        else if (winmenu.activeInHierarchy)
        {
            Debug.Log("Prendo nome dalla vittoria");
            myname = winmenu.gameObject.transform.GetChild(0).GetComponent<WinMenu>().TakeName();
            Debug.Log("Vincitore" + myname);
        }
        table.AddHighscoreEntry(ScoreManager.instance.getScore(), myname);
    }
        
      

    public int getStarting()
    {
        return startingHealth;
    }


    public bool getDead()
    {
        return isDead;
    }

    public int getCurrentH()
    {
        return currentHealth;
    }

    public void heal()
    {
        if (getStarting() == getCurrentH())
        {
            // do nothing
        }
        else if (getCurrentH() + 20 >=getStarting())
        {
            GetComponent<PlayerHealth>().restoreH();
        }
        else
        {
            currentHealth += 20;
        }
    }

    public void restoreH()
    {
        currentHealth = startingHealth;
    }


}
