using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    
    [SerializeField] private GameObject HUD;


    [SerializeField] private GameObject nameBox;
    [SerializeField] private GameObject waveManager;



    private void Awake() {
        Time.timeScale = 0;
        SoundManager.instance.stopMain();
        waveManager.SetActive(false);
        HUD.SetActive(false);
    }

    public string TakeName()
    {
        return nameBox.GetComponent<Text>().text;

    }
}
