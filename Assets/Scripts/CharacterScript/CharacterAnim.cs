using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnim : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(int walk)
    {
        anim.SetInteger("Walk", walk);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

}
