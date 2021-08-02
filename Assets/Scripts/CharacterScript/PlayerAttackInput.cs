using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    private CharacterAnim playerAnim;
    // Start is called before the first frame update


    GameObject staff;
    private float timeToAtt;

   // GameObject staff;


    void Awake()
    {
        playerAnim = GetComponent<CharacterAnim>();
        staff = GameObject.FindGameObjectWithTag("Staff");
        timeToAtt = staff.GetComponent<Staff>().timeToSpawn;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyBindingManager.KM.attack))
        {
            StartCoroutine("delayAttack");
        }
    }

    IEnumerator delayAttack()
    {
        yield return new WaitForSeconds(timeToAtt);
        playerAnim.Attack();
    }

}

   
