using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrubAttack : EnemyAttack
{
    // Start is called before the first frame update
    new void Awake()
    {
        base.Awake();
        timeBetweenAttacks = 0.7f;
        attackDamage = 10;
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
