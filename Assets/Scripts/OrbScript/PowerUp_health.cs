using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_health : PowerUp
{
   
    private Despawn ds;

    new void Awake()
    {
        base.Awake();
        effect = gameObject.transform.GetChild(3).gameObject;
        effect.SetActive(true);
        ds = GetComponent<Despawn>();
        multiplier = 20;
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character1"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    protected override IEnumerator Pickup(Collider player)
    {
          // to be fixed...
        ds.setPicked();
        if (effect.activeInHierarchy) effect.SetActive(false);
        base.textAnim();

        player.gameObject.GetComponent<PlayerHealth>().heal();
        

       // Debug.Log("Cure player " + player.GetComponent<PlayerHealth>().getCurrentH());
        yield return new WaitForSeconds(3f);
        base.disableTextAnim();
        // Destroy(gameObject);
    }
}
