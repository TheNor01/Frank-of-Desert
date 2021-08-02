using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension    //static
{


    public static void Spawn(this Transform trans, Transform spawnPoint,Transform playertr)  // extension
    {
        trans.position = spawnPoint.position;
        //trans.rotation = Quaternion.identity;
        trans.rotation = playertr.rotation;
        trans.gameObject.SetActive(true);

    }
}
