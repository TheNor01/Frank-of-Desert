using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    public static EnemySpawnManager instance;
    [SerializeField] private GameObject[] Enemies;
    [SerializeField] private GameObject[] enemyList;
    private int enemyLength;

    [SerializeField] private Transform[] SpawnPoints;
   // [SerializeField] private int spLength;

    [SerializeField] private int timeToSpawn;

    private float tEnemySpawn = 0;
    private int enemyCounter = 0;


    private void Awake()
    {
        instance = this;
    }

    IEnumerator generateList(int numberEnemies)
    {
        enemyLength = numberEnemies;
        enemyList = new GameObject[enemyLength];
        int index;
        for (int i = 0; i < enemyLength; i++)
        {
            int spIndex = Random.Range(0, SpawnPoints.Length);
            int enIndex = Random.Range(0, 10);
            


            if (enIndex <= 7) index = 0;
            else index = 1;


            //Debug.Log("I : "+index);
            enemyList[i] = GameObject.Instantiate(Enemies[index], SpawnPoints[spIndex].position, SpawnPoints[spIndex].rotation);
            enemyList[i].SetActive(false);
        }
        StartCoroutine("generateSpawn");
        yield return 0;
    }


    IEnumerator generateSpawn()
    {
       // Debug.Log("qui");
        while (true)
        {
            tEnemySpawn += Time.deltaTime;
            if (tEnemySpawn > timeToSpawn)
            {
                SpawnEnemy();
                //Debug.Log("dentro ");
            }
            yield return null;
        }
        
    }




    public void SpawnEnemy() {
        tEnemySpawn = 0;

        for (int i = enemyCounter; i < enemyLength; i++) {
            if (!enemyList[i].activeInHierarchy) {
                enemyList[i].SetActive(true);
                enemyCounter = i + 1;
                //Debug.Log(enemyCounter);
                //break;
            }
            if (enemyCounter == enemyLength){
                enemyCounter = 0;
                StopCoroutine("generateSpawn");
                StopCoroutine("generateList");
               // Debug.Log("stopped co");
            }

        }
        

    }
}
