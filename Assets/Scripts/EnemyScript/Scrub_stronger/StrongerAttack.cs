using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongerAttack : EnemyAttack
{
    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        timeBetweenAttacks = 0.3f;
        attackDamage = 20;
    }

    protected override void prepareAttack()
    {
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && playerInRange && base.enemyHealth.getCurrent() > 0)
        {
            Attack();
        }
    }

    protected override void Attack()
    {
        timer = 0f;
        if (base.playerHealth.getCurrentH() > 0)
        {
            base.playerHealth.TakeDamage(attackDamage);

        }
    }
}
