using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_star : PowerUp
{
    private Despawn ds;
    
    // public GameObject pickupEffect;


    new void Awake()
    {
        base.Awake();
        effect = gameObject.transform.GetChild(3).gameObject;
        effect.SetActive(true);
        ds = GetComponent<Despawn>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character1"))
        {
            Debug.Log("trigger start");
            StartCoroutine(Pickup(other));
        }
    }

    protected override IEnumerator Pickup(Collider player)
    {
      
        ds.setPicked();
        if (effect.activeInHierarchy) effect.SetActive(false);
        player.GetComponentInChildren<ChangeStar>().powerUp();
        player.GetComponent<PlayerHealth>().Invincible = true;
        base.textAnim();
        yield return new WaitForSeconds(5f);


        base.disableTextAnim();
        player.GetComponent<PlayerHealth>().Invincible = false;
        player.GetComponentInChildren<ChangeStar>().restoreSkin();
        //Destroy(gameObject);
    }
}
