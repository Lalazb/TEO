using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    //integrar swimming y los triggers
    //public variables
    public CharacterController controller;
    public float speed = 8;
    public float swimSpeed = 2;
    public float dash = 100;
    public float jumpForce = 10;
    public float gravity = -20;
    public float moveX = 5;
    public float moveY = 10;
    public float waterGravity = -2;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isSwimming = false;
    public bool ableToMakeDoubleJump = true;

    //private variables
    private bool isGrounded=true;
    private Vector3 direction;
    private Rigidbody body;
    // Update is called once per frame

    public void FixSpriteHorizontalOrientation()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    private void Start()
    {
        this.body = this.GetComponent<Rigidbody>();
    }

    //probar con ray
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        
        
        if (isSwimming)
        {
            Swimming();
        }
        else
        {
            this.FixSpriteHorizontalOrientation();
            JumpingVer2();

            //Dash
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                direction.x = hInput * dash;
                controller.Move(direction * Time.fixedDeltaTime);
            }
           
            direction.x = hInput * speed;
            controller.Move(direction * Time.fixedDeltaTime);
            
        }
    }

    void Swimming()
    {
        if (Input.GetButton("Jump"))
        {
            body.AddForce(Vector3.up * moveY, ForceMode.Impulse);
        }
        else
        {
            body.velocity = new Vector2(moveX, waterGravity);
        }
    }

    void Jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            direction.y = -1;
            if (Input.GetButton("Jump"))
            {
                ableToMakeDoubleJump = true;
                direction.y = jumpForce;
                //Debug.Log("Jump");
            }
        }
        else //caida
        {
            direction.y += gravity * Time.fixedDeltaTime;
            Debug.Log("Gravity");
            if (ableToMakeDoubleJump & Input.GetButtonUp("Jump"))
            {
                direction.y = jumpForce;
                ableToMakeDoubleJump = false;
            }
        }
    }

    void JumpingVer2()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
         if (Input.GetButton("Jump") && isGrounded)
         {
                direction.y = -1;
                ableToMakeDoubleJump = true;
                direction.y = jumpForce;        
         }
         else //caida
         {
            direction.y += gravity * Time.fixedDeltaTime;
            if (ableToMakeDoubleJump & Input.GetButtonUp("Jump")) //Tiene ButtonUp por lo que solo en un momento muy específico puedes hacer el doble salto; cuando APENAS va a caer
            {
                direction.y = jumpForce;
                ableToMakeDoubleJump = false;
            }
         }
        
    }

}
