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
    public float waterGravity = -0.01f;
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
        this.FixSpriteHorizontalOrientation();

        float hInput = Input.GetAxis("Horizontal");
        
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        if(isSwimming)
        {
            direction.y = -1;

            if (Input.GetButtonDown("Jump"))
            {                
                direction.y = jumpForce;
                Debug.Log("Swim");
            }

            direction.y += waterGravity * Time.fixedDeltaTime;
            Debug.Log("Water Gravity");

            direction.x = hInput * swimSpeed;
            controller.Move(direction * Time.fixedDeltaTime);
        }
        else
        {
            //revisar lineas 48-65 iniciando por jump
            if (isGrounded)
            {
                direction.y = -1;
                if(Input.GetButtonDown("Jump"))
                {
                    ableToMakeDoubleJump = true;
                    direction.y = jumpForce;
                    //Debug.Log("Jump");
                }
            }
            else
            {   
                direction.y += gravity * Time.fixedDeltaTime;
                Debug.Log("Gravity");
                if (ableToMakeDoubleJump & Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                    ableToMakeDoubleJump = false;
                }
            }
            //Dash
            if(Input.GetKeyDown(KeyCode.Tab))
            {
                direction.x = hInput * dash;
                controller.Move(direction * Time.fixedDeltaTime);
            }
            else
            {
                direction.x = hInput * speed;
                controller.Move(direction * Time.fixedDeltaTime);
            }
        }
    }
}
