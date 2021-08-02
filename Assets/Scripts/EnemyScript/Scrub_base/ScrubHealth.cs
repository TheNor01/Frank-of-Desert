using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubHealth : EnemyHealth
{


    // Update is called once per frame
    new void Awake()
    {
        base.Awake();
        scoreValue = 10;
        base.enemyType = 1.0f;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            base.Death();
           // updateScore();
        }
    }

    public void updateScore() //override
    {
        ScoreManager.instance.updateText(scoreValue);
        SoundManager.instance.PlayEnemyDestroy();
    }
}
