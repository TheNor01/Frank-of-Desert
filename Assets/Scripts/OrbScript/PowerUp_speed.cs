using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_speed : PowerUp
{
    private Despawn ds;
    new void Awake()
    {
        base.Awake();
        effect = gameObject.transform.GetChild(3).gameObject;
        effect.SetActive(true);
        ds = GetComponent<Despawn>();
        multiplier = 2.5f;
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

        Debug.Log("Picked up PW_speed");
        base.textAnim();
        if (effect.activeInHierarchy) effect.SetActive(false);
        ds.setPicked();
        player.GetComponent<CharacterMovement>().speed *= multiplier;
        // Debug.Log("Prima buff"+player.GetComponent<CharacterMovement>().speed);


        //Debug.Log()
        yield return new WaitForSeconds(3f);
        player.GetComponent<CharacterMovement>().speed /= multiplier;
        //Debug.Log("Dopo buff"+player.GetComponent<CharacterMovement>().speed);
        base.disableTextAnim();
        //Destroy(gameObject);

    }

}

