using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 0.4f;
    public float gravity = 1.5f;
    public float rot = 0f;
    public float rotSpeed = 120;

    private CharacterController controller;
    private CharacterAnim playerAnim;
    private PlayerHealth playerHealth;


    private bool cooldown = false;
    private float verticalVel;

    public bool isJumping = false;
    private float jumpForce = 8f;

    public KeyCode forward;
    public KeyCode backward;
    public KeyCode right;
    public KeyCode left;
    public KeyCode space;

    public bool isGrounded;
    public float rotX;
    public float rotY;
    Vector3 moveDir1 = Vector3.zero;

    // Animator anim;
    private float rotateDegrees;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerAnim = GetComponent<CharacterAnim>();
        playerHealth = GetComponent<PlayerHealth>();

    }

    private void Update()
    {
        // Debug.Log(speed);
        if (Time.timeScale == 0)
            return;



        Move();
        rotX -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rotY += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        AnimateWalk();
        isGrounded = controller.isGrounded;

    }


    public void Move()
    {
        BasicMovement();

        if (controller.isGrounded)
        {
            isJumping = false;
            verticalVel = -gravity * Time.deltaTime;

            if (playerHealth.Invincible)
            {
                if (cooldown == false)
                {
                    if (Input.GetKey(KeyBindingManager.KM.jump))
                    {
                        //anim.SetInteger("Walk", 0);
                        verticalVel = jumpForce;
                        moveDir1 = new Vector3(0, verticalVel, 0);
                        moveDir1 = transform.TransformDirection(moveDir1);
                        isJumping = true;
                        Invoke("ResetCooldown", 0.5f);
                        cooldown = true;
                    }
                    
                }
            }
         }
         else verticalVel = -gravity * Time.deltaTime;
       
        moveDir1.y = verticalVel;
        controller.Move(moveDir1);


    }

    private void BasicMovement()
    {
        if(Input.GetKey(KeyBindingManager.KM.forward))
        {
            // anim.SetInteger("Walk", 1);
            moveDir1 = new Vector3(0, 0, 1);
            moveDir1 = moveDir1 * speed * Time.deltaTime;
            moveDir1 = transform.TransformDirection(moveDir1);
            playerAnim.Walk(1);
        }
        if (Input.GetKeyUp(KeyBindingManager.KM.forward))
        {
            //  anim.SetInteger("Walk", 0);
            moveDir1 = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyBindingManager.KM.backward))
        {
            // anim.SetInteger("Walk", 1);
            moveDir1 = new Vector3(0, 0, -1);
            moveDir1 = moveDir1 * speed  * Time.deltaTime;
            moveDir1 = transform.TransformDirection(moveDir1);
            playerAnim.Walk(1);
        }
        if (Input.GetKeyUp(KeyBindingManager.KM.backward))
        {
            //anim.SetInteger("Walk", 0);
            moveDir1 = new Vector3(0, 0, 0);

        }
        if (Input.GetKey(KeyBindingManager.KM.right) && !(Input.GetKey(KeyBindingManager.KM.left)))
        {
            //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            //transform.eulerAngles = new Vector3(0, rot, 0);
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * rotSpeed;
        }
        else if (Input.GetKey(KeyBindingManager.KM.left) && !(Input.GetKey(KeyBindingManager.KM.right)))
        {
            //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
            //transform.eulerAngles = new Vector3(0, rot, 0);
            transform.position -= transform.TransformDirection(Vector3.right) * Time.deltaTime * rotSpeed;
        }
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.tag == "Scrub")
        {
            Debug.Log("collide player");
           
            //transform.position = transform.InverseTransformDirection(new Vector3(transform.position.x, 0, transform.position.z));
        }
    }

    void AnimateWalk()
    {
        if(controller.velocity.magnitude == 0.0f) { 
        
            playerAnim.Walk(0);
        }
     
    }

    void ResetCooldown()
    {
        cooldown = false;
    }

}