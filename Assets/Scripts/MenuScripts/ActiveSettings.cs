using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSettings : MonoBehaviour
{
    private void Awake()
    {
        gameObject.transform.GetChild(3).GetComponent<SettingsMenu>().Start();
    }

}
