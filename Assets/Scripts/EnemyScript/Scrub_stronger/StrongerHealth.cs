using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerHealth : EnemyHealth
{


    // Update is called once per frame
    new void Awake()
    {
        base.Awake();
        scoreValue = 20;
        base.enemyType = 2.2f;
    }

    private void Update()
    {
        //print("Curr he" + currentHealth);

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
