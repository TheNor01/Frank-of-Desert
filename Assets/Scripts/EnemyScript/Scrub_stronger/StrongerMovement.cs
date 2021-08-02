using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerMovement : EnemyMovement
{

    new void Awake()
    {
        base.Awake();
        base.nav.speed = 1.3f;
    }
}
