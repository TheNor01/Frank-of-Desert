using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSettings : MonoBehaviour
{

    public void scaleUp()
    {
        if (!transform.gameObject.activeInHierarchy)
        {
            transform.gameObject.SetActive(true);
            Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
            gameObject.transform.localScale = scale;
        }
        else
        {
            Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);
            gameObject.transform.localScale = scale;
        }

    }
}
