using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed = 0.4f;
    public float gravity = 50f;
    public float rot = 0f;
    public float rotSpeed = 120;

    private CharacterController controller;
    private CharacterAnim playerAnim;

    private float verticalVel;

    private float jumpForce = 3f;

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

    }

    private void Update()
    {
        // Debug.Log(speed);
        if (Time.timeScale == 0)
            return;



        Move1();
        rotX -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rotY += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, rotY, 0);
        AnimateWalk();
        isGrounded = controller.isGrounded;

    }


    public void Move1()
    {
        if (controller.isGrounded)
        {
            verticalVel = -gravity * Time.deltaTime;
            if (Input.GetKey(forward))
            {
                // anim.SetInteger("Walk", 1);
                moveDir1 = new Vector3(0, 0, 1);
                moveDir1 = moveDir1 * speed;
                moveDir1 = transform.TransformDirection(moveDir1);
                playerAnim.Walk(1);
            }
            if (Input.GetKeyUp(forward))
            {
                //  anim.SetInteger("Walk", 0);
                moveDir1 = new Vector3(0, 0, 0);

            }
            if (Input.GetKey(backward))
            {
                // anim.SetInteger("Walk", 1);
                moveDir1 = new Vector3(0, 0, -1);
                moveDir1 = moveDir1 * speed;
                moveDir1 = transform.TransformDirection(moveDir1);
                playerAnim.Walk(1);
            }
            if (Input.GetKeyUp(backward))
            {
                //anim.SetInteger("Walk", 0);
                moveDir1 = new Vector3(0, 0, 0);

            }
            if (Input.GetKey(space))
            {
                //anim.SetInteger("Walk", 0);
                verticalVel = jumpForce;
                moveDir1 = new Vector3(0, verticalVel, 0);
                moveDir1 = transform.TransformDirection(moveDir1);

            }
            if (Input.GetKey(right) && !(Input.GetKey(left)))
            {
                //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, rot, 0);
                transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * rotSpeed;
            }
            else if (Input.GetKey(left) && !(Input.GetKey(right)))
            {
                //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                //transform.eulerAngles = new Vector3(0, rot, 0);
                transform.position -= transform.TransformDirection(Vector3.right) * Time.deltaTime * rotSpeed;
            }



        }
        else
        {
            verticalVel = -gravity * Time.deltaTime;
        }
        moveDir1.y -= gravity * Time.deltaTime;
        controller.Move(moveDir1);

 
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

}