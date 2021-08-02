﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindingManager : MonoBehaviour
{

    public static KeyBindingManager KM;

    public KeyCode jump { get; set;}
    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode right { get; set; }
    public KeyCode left { get; set; }
    public KeyCode attack { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        if (KM == null)
        {
            DontDestroyOnLoad(gameObject);
            KM = this;       // SINGLETON
            Debug.Log("qui");
        }
        else if (KM != this)
        {
            Destroy(gameObject);
        }


        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        attack = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("attackKey", "K"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
