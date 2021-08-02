using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CheckPlayerAbove : MonoBehaviour
{

    private EnemyHealth eh;
    private BoxCollider bc;
    private CharacterMovement cm;
    // Start is called before the first frame update
    void Awake()
    {
        eh = GetComponentInParent<EnemyHealth>();
        cm= GameObject.FindGameObjectWithTag("Character1").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(eh.currentHealth);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Character1")
        {
            if (cm.isJumping)
            {
                Debug.Log("Player sopra ");
                cm.isGrounded = false;
                cm.isJumping = true;
                if (cm.isJumping) eh.TakeDamage(100);
            }
        //    else { Debug.Log("no dmg"); }
        }
    }
}
