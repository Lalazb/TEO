using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 direction;
    public float speed = 8;
    public float dash = 100;
    public float jumpForce = 10;
    public float gravity = -20;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isSwimming = false;

    public bool ableToMakeDoubleJump = true;

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

    void Update()
    {
        this.FixSpriteHorizontalOrientation();

        float hInput = Input.GetAxis("Horizontal");

        bool isGrounded = Physics.CheckSphere(groundCheck.position,0.2f,groundLayer);
      
        if (isGrounded)
        {
            direction.y = -1;
            ableToMakeDoubleJump = true;
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpForce;
            }
        }
        else
        {   
            direction.y += gravity * Time.deltaTime;
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
            controller.Move(direction * Time.deltaTime);
        }
        else
        {
            direction.x = hInput * speed;
            controller.Move(direction * Time.deltaTime);
        }
    }
}
