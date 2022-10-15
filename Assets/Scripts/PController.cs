using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float jumpForce = 10f;
    public float gravity = -20f;
    public float NT = 0f;
    public float resta = 1;
    //public float waterGravity;
    public bool hability;
    public bool isGrounded;
    public bool isSwiming;
    public bool ableToMakeDoubleJump;
    public Transform model;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask waterMask;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Slow
        if (NT > 0)
            {
                speed = 5;
                NT -= resta * Time.deltaTime;
            }
            else
            {
                speed = 10;
            }
        if (TeoState.nslow == 1)
        {
            NT = 4;
            TeoState.nslow = 0;
            TeoState.SavePrefs();
        }

        //Move
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput * speed;

        //Flip
        if (hInput != 0)
        {
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(0, 0, hInput));
            model.rotation = newRotation;
        }

        controller.Move(direction * Time.deltaTime);

        //Jump
        if (hability == false)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            direction.y += gravity * Time.deltaTime;
            if (isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                }
            }
        }

        //DoubleJump
        if (hability == true)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
            direction.y += gravity * Time.deltaTime;
            if (isGrounded)
            {
                ableToMakeDoubleJump = true;
                if (Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                }
            }
            else
            {
                if (ableToMakeDoubleJump & Input.GetButtonDown("Jump"))
                {
                    direction.y = jumpForce;
                    ableToMakeDoubleJump = false;
                }
            }
        }

        //Swiming

        isSwiming = Physics.CheckSphere(groundCheck.position, 0.2f, waterMask);

        if (isSwiming)
        {
            gravity = -4f;
            speed = 5f;
            // jumpForce = 6f;
            direction.y += gravity * Time.deltaTime;
            if (Input.GetButtonUp("Jump"))
            {
                direction.y = jumpForce;
                //float hInput = Input.GetAxis("Horizontal");
                direction.x = hInput * speed;
            }
        }
        else
        {
            speed = 8f;
            gravity = -20f;
            jumpForce = 10f;
        }

    }
}
