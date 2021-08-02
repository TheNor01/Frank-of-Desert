using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private float timeToDesp = 6f;

    public bool isPicked = false;

    [SerializeField] private GameObject sphere;
    SphereCollider sp;
    private void Awake()
    {
        StartCoroutine("despawnOrb");
        sp = GetComponent<SphereCollider>();
    }

    IEnumerator despawnOrb()
    {
        yield return new WaitForSeconds(timeToDesp);
        Destroy(gameObject);
    }


    public void setPicked()
    {
        isPicked = true;
        sp.enabled = false;
        sphere.GetComponent<MeshRenderer>().enabled = false;
        checkPicked();

    }

    void checkPicked()
    {
        if (isPicked) {
            StopCoroutine("despawnOrb");
            StartCoroutine("despawnOrb");
        }
    }
}
