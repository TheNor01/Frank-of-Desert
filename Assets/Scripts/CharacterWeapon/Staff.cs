using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] GameObject[] fireballsList;
    int firelength = 10;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject fireball;
    [SerializeField] public float timeToSpawn;
    GameObject player;
    Transform playertras;

    [SerializeField] private int fireballsC = 0;
    private bool fireFound = false;
    //private int x = 0;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Character1");
        playertras = player.transform;
        fireballsList = new GameObject[firelength];
        generateFire();
    }

    void generateFire()
    {
        for (int i = 0; i < firelength; i++)
        {
            fireballsList[i] = Instantiate(fireball, spawnPoint.position, playertras.rotation);
            // fireballsList[i].GetComponent<HitBullet>().SetBulletType((int)myTurret);
            fireballsList[i].SetActive(false);
        }
    }


    IEnumerator Shoot()
    {
            // Debug.Log("sparo");
          yield return new WaitForSeconds(timeToSpawn); 
            //Debug.Log("after yield");
            SpawnFire();
    }

    void SpawnFire() {
      //  Debug.Log("Spawnfire");
        fireFound = false;
       
        while (!fireFound)
       {
          //  Debug.Log("Spawnfire2");
            for (int i = fireballsC; i < firelength; i++)
           {
                if (!fireballsList[i].activeInHierarchy)
                {
                 //   Debug.Log("Spawnfire3");
                    fireballsList[i].GetComponent<Fireball>().Spawn(spawnPoint,playertras);
                    fireballsC = i + 1;
                    fireFound = true;
                    break;
                }
                if (i == firelength - 1)
                {
                    fireballsC = 0;
                    generateFire();
                }
           }
            if (fireballsC == firelength) {
                fireballsC = 0;
                generateFire();
            }

        }
    }

}

