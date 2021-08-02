using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour,IProjectile
{
    private int damagePershot = 40;
    private int baseDamage;

    GameObject player;

    private float LifeTimeTimer = 5.0f;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character1");
        Physics.IgnoreCollision(player.transform.GetComponent<Collider>(), this.transform.GetComponent<Collider>());
       // Debug.Log(damagePershot);
        baseDamage = damagePershot;
    }

    private void OnEnable()
    {
        StartCoroutine("lifeTime");
    }


    public int getDamage()
    {
        return damagePershot;
    }

    public int getBaseDamage()
    {
        return baseDamage;
    }

    private void destroy()
    {
        gameObject.SetActive(false);
        gameObject.layer = 15;
    }

    public void Spawn(Transform spawnPoint,Transform playtr)
    {
        transform.Spawn(spawnPoint,playtr);  // CHIAMATA EXTENSION
    }



    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(LifeTimeTimer);
        gameObject.SetActive(false);
       
            
    }




}
