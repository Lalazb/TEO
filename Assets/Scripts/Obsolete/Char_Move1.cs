using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Move1 : MonoBehaviour
{
    //movement Variables

    public float moveSpeed;

    Rigidbody myRB;

    //jumping
    bool grounded = false;
    Collider[] groundCollision;
    float GroudCheckRadius = 0.2f;

    public LayerMask groundLayer;
    public Transform ground_Check;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //For Jumping
        groundCollision = Physics.OverlapSphere(ground_Check.position, GroudCheckRadius, groundLayer);
        if (groundCollision.Length > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if(grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myRB.AddForce(new Vector3(0, jump, 0));
        }
    }
}
