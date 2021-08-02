using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] GameObject[] fireballsList;
    int firelength = 10;
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject fireball;
    [SerializeField] float timeToSpawn;


    [SerializeField] private int fireballsC = 0;
    private bool fireFound = false;
    private int x = 0;

    // Start is called before the first frame update
    void Awake()
    {
        fireballsList = new GameObject[firelength];
        for (int i = 0; i < firelength; i++)
        {
            fireballsList[i] = Instantiate(fireball, spawnPoint.position, spawnPoint.rotation);
           // fireballsList[i].GetComponent<HitBullet>().SetBulletType((int)myTurret);
            fireballsList[i].SetActive(false);
        }
    }


    IEnumerator Shoot()
    {
            Debug.Log("sparo");
          yield return new WaitForSeconds(timeToSpawn); // crash
          // yield return null;
            Debug.Log("after yield");
            SpawnFire();
    }

void SpawnFire() {
        Debug.Log("Spawnfire");
    fireFound = false;
       
   // while (!fireFound)
  //  {
    //    for (int i = firelength; i < firelength; i++)
    //    {
            if (!fireballsList[x].activeInHierarchy)
            {
                fireballsList[x].GetComponent<Fireball>().Spawn(spawnPoint);
                fireballsC = 0 + 1;
                fireFound = true;
            x++;
                //break;
            }
          //  if (i == firelength - 1)
          //      fireballsC = 0;
     //   }
       // if (fireballsC == firelength)
      //      fireballsC = 0;

   // }
}
}

