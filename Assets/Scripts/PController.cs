using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 5f;
    public float jumpForce = 8f;
    public float gravity = -16f;
    public float NT = 0f;
    public float resta = 1;
    public bool moving;
    public bool hability;
    public bool isGrounded;
    public bool ableToMakeDoubleJump;
    public Transform model;
    public Transform groundCheck;
    public LayerMask groundLayer;
    

    private Vector3 direction;
    Animator animator;
    private bool moveDetected;
    private Gun waterBomb;

    enum TeoStates
    {
        Idle,
        Walk,
        Jump,
        DoubleJump,
        Caida,
        Landing,
        WaterStreamIn,
        WaterStreamLoop,
        WaterStreamOut
    };
    TeoStates state;


    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        animator = GetComponent<Animator>();
        ChangeState(TeoStates.Idle);
        waterBomb = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();

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
            case TeoStates.WaterStreamIn:
                WaterStreamIn();
                break;
            case TeoStates.WaterStreamOut:
                WaterStreamOut();
                break;
        }
        //if (waterBomb.enabled == true)
        //{
            if (Input.GetKeyDown(KeyCode.J))
            {
                ChangeState(TeoStates.WaterStreamIn);
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                ChangeState(TeoStates.WaterStreamOut);
            }
        //}

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
                //animator.SetBool("doubleJump", false);
                break;
            case TeoStates.Caida:
                if(isGrounded)
                {
                    animator.SetBool("isGrounded", true);
                    animator.SetBool("doubleJump", true);
                }
                break;
            case TeoStates.Landing:
                animator.SetBool("isGrounded", true);
                break;
            case TeoStates.WaterStreamIn:
                animator.SetBool("waterBomb",true);
                break;
            case TeoStates.WaterStreamOut:
                animator.SetBool("waterBomb", false);
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
        }
    }

    void Walk()
    {
        //Slow
        if (NT > 0)
        {
            speed = 3;
            NT -= resta * Time.deltaTime;
        }
        else
        {
            speed = 5;
        }
        if (TeoState.nslow == 1)
        {
            NT = 4;
            TeoState.nslow = 0;
            TeoState.SavePrefs();
        }
       
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
                    if (isGrounded == false)
                    {
                        ChangeState(TeoStates.Jump);
                       /* if (ableToMakeDoubleJump == false)
                        {
                            ChangeState(TeoStates.DoubleJump);
                        }*/
                    }
                }
            }

            controller.Move(direction * Time.deltaTime);
            
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

        if(hability==true)
        {
            //DoubleJump();
            ChangeState(TeoStates.DoubleJump);
        }
        else
        {
            ChangeState(TeoStates.Caida);
        }
    }

    void DoubleJump()
    {
        //DoubleJump
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
                if (ableToMakeDoubleJump && Input.GetButtonDown("Jump"))
                {
                    animator.SetBool("doubleJump", false);
                    direction.y = jumpForce;
                    ableToMakeDoubleJump = false;
                }
            }
        ChangeState(TeoStates.Caida);
    }

    void WaterStreamIn()
    {

    }

    void WaterStreamOut()
    {

    }
}