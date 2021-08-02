using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnPower;
    [SerializeField] private GameObject waveManager;


    [SerializeField] private GameObject nameBox;

    private void Awake()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
        waveManager.SetActive(false);
        HUD.SetActive(false);
        player.GetComponent<CharacterMovement>().enabled = false;
        spawnPower.gameObject.transform.GetChild(1).GetComponent<SpawnOrb>().enabled = false;
    }

    public string TakeName()
    {
        return nameBox.GetComponent<Text>().text;

    }
}