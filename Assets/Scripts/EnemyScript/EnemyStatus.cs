using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private bool weakStatus = false;
    
    private void Update()
    {
        //Debug.Log("Weak : " + weakStatus);
    }

    public bool getWeak()
    {
        return weakStatus;
    }

    public void setWeak()
    {
        weakStatus = true;
    }

    public void resetWeak()
    {
        weakStatus = false;
    }
}
