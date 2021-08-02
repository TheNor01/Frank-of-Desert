using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public enum SpawnState {SPAWNING,WAITING,COUNTING};
    [SerializeField] Canvas waveCanvas;

    [SerializeField] GameObject winmenu;

    GameObject ChildWave;

    [System.Serializable]
    public class Wave
    {
        public string name;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeBtWaves = 5f;
    public float waveCd;

    private float searchCd = 3f;
    private float numberEnemies;

    private SpawnState state = SpawnState.COUNTING;

    private void Awake()
    {
        
        ChildWave = waveCanvas.transform.GetChild(1).gameObject;
    }
    private void Start()
    {
        waveCd = timeBtWaves;
        numberEnemies = 3;
    }

    private void Update()
    {
        Debug.Log(state);
        Debug.Log(waveCd);
        if (state == SpawnState.WAITING)
        {
            if (!EnemyAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCd <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCd -= Time.deltaTime;
        }

        
    }

    void WaveCompleted() {
        Debug.Log("Wave completed");

        state = SpawnState.COUNTING;
        waveCd = timeBtWaves;
        if( nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETED");
            winmenu.SetActive(true);
            EnemySpawnManager.instance.enabled = false;
            SoundManager.instance.volueMainDown();
        }
        else
        {
            nextWave++;
        }

       
    }

    bool EnemyAlive()
    {
        Debug.Log("Controllo nemici");
       searchCd -= Time.deltaTime;
        if (searchCd <= 0f)
        {
            searchCd = 1f;
            if (GameObject.FindGameObjectWithTag("Scrub") == null)
            {
                Debug.Log("Nessuno vivo");
                return false;
            }
        }
        Debug.Log("nemico vivo");
        return true;
    }

    IEnumerator SpawnWave( Wave _wave)
    {
        Debug.Log("Spawing Wave");
        state = SpawnState.SPAWNING;
        ChildWave.GetComponent<Text>().text = (nextWave + 1).ToString();

        if(EnemySpawnManager.instance.enabled) EnemySpawnManager.instance.StartCoroutine("generateList",numberEnemies);
        numberEnemies += PlayerPrefs.GetInt("Diff");  // preparo alla prossima wave 
        state = SpawnState.WAITING; // e aspetto
        yield break;
    }
}
