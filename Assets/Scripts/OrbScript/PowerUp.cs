using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PowerUp : MonoBehaviour
{
    protected float multiplier;
    protected  GameObject powerUpCanvas;
    
    protected Text text;

    protected GameObject effect;

    protected void Awake()
    {
        powerUpCanvas = GameObject.FindGameObjectWithTag("TextPower");
        text = powerUpCanvas.transform.GetChild(0).GetComponent<Text>();
    }


    // public GameObject pickupEffect;
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character1"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    protected void textAnim()
    {
        text.gameObject.SetActive(true);
        Debug.Log("qui");
        //text.gameObject.SetActive(false);
    }

    protected void disableTextAnim()
    {
        text.gameObject.SetActive(false);
    }

    protected virtual IEnumerator Pickup(Collider player)
    {
        yield return new WaitForSeconds(0);
    }
}
