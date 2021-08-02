using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubMovement : EnemyMovement
{
    new void Awake()
    {
        base.Awake();
        base.nav.speed = 3f;
    }
}
