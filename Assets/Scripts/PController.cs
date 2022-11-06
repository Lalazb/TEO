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
    public bool moving;
    public bool hability;
    public bool isGrounded;
    public bool ableToMakeDoubleJump;
    public Transform model;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool moveDetected;

    private Vector3 direction;
    Animator animator;

    enum TeoStates
    {
        Idle,
        Walk,
        Jump,
        DoubleJump,
        Caida,
        Landing,
        WaterStream
    };
    TeoStates state;


    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        animator = GetComponent<Animator>();
        ChangeState(TeoStates.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        DoubleJump();
        //Prueba
        if (TeoState.vidas <= 0 || TeoState.resp == 1)
        {
            StartCoroutine(PausaRes());
        }

        switch(state)
        {
            case TeoStates.Idle:
                Idle();
                break;
            case TeoStates.Walk:
                Walk();
                break;
            case TeoStates.Jump:
                Jump();
                break;
            case TeoStates.DoubleJump:
                DoubleJump();
                break;
            case TeoStates.Caida:
                Caida();
                break;
            case TeoStates.Landing:
                Landing();
                break;
            case TeoStates.WaterStream:
                WaterStream();
                break;
        }

    }
    private void CheckRoof()
    {
        RaycastHit hitInfo = new RaycastHit();
        Debug.DrawRay(transform.position, Vector3.up * 1.1f, Color.red);
        if (Physics.Raycast(transform.position, Vector3.up, out hitInfo, 1.1f, groundLayer))
        {
            gravity = -350f;
        }
    }

    IEnumerator PausaRes()
    {
        moving = false;
        yield return new WaitForSeconds(1);
        NT = 0;
        moving = true;
    }
    
    void ChangeState(TeoStates newState)
    {
        switch (newState)
        {
            case TeoStates.Idle:
                animator.SetBool("isGrounded", true);
                animator.SetBool("isMoving", false);
                break;
            case TeoStates.Walk:
                animator.SetBool("isGrounded", true);
                animator.SetBool("isMoving", true);
                break;
            case TeoStates.Jump:
                animator.SetBool("isGrounded", false);
                break;
            case TeoStates.DoubleJump:
                animator.SetBool("isGrounded", false);
                animator.SetBool("doubleJump", false);
                break;
            case TeoStates.Caida:
                
                break;
            case TeoStates.Landing:
                animator.SetBool("isGrounded", true);
                break;
            case TeoStates.WaterStream:
                animator.ResetTrigger("waterBomb");
                break;
        }
        state = newState;
    }


    void Idle()
    {
        ChangeState(TeoStates.Idle);
        if(isGrounded==false)
        {
            ChangeState(TeoStates.Jump);
            if(ableToMakeDoubleJump==false)
            {
                ChangeState(TeoStates.DoubleJump);
            }
        }
    }

    void Walk()
    {
        
        //Slow
       /* if (NT > 0)
        {
            speed = 5;
            NT -= resta * Time.deltaTime;
        }
        else
        {
            speed = 8;
        }
        if (TeoState.nslow == 1)
        {
            NT = 4;
            TeoState.nslow = 0;
            TeoState.SavePrefs();
        }
       */
        //Move
        if (moving == true)
        {
            float hInput = Input.GetAxis("Horizontal");
            direction.x = hInput * speed;
            moveDetected = false;
            if (moveDetected== false)
            {
                ChangeState(TeoStates.Idle);
            }

            //Flip
            if (hInput != 0)
            {
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(hInput, 0, 0));
                model.rotation = newRotation;
                moveDetected = true;
                if(moveDetected==true)
                {
                    ChangeState(TeoStates.Walk);
                }
            }

            controller.Move(direction * Time.deltaTime);
            if (isGrounded == false)
            {
                ChangeState(TeoStates.Jump);
                /*if (ableToMakeDoubleJump == false)
                {
                    ChangeState(TeoStates.DoubleJump);
                }*/
            }
        }
    }

    void Jump()
    {
        //Jump
        if (hability == false)
        {
            CheckRoof();
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
             
    }

    void DoubleJump()
    {
        //DoubleJump
        if (hability == true)
        {
            CheckRoof();
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
            animator.SetBool("doubleJump", true);
        }
    }

    void Caida()
    {

    }

    void Landing()
    {

    }

    void WaterStream()
    {

    }

}