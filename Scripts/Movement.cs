using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    //Control Keys
    public KeyCode dash = KeyCode.Tab;

    //Movement Variables
    public float moveSpeed = 5f;
    public float dashSpeed = 25.0f;
    public float moveVelocity = 1f;

    public bool canWalk = true;
    public bool canDash = true;

    //Player interactors
    private Rigidbody body;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor"))
        {
            this.canWalk = true;
            this.canDash = true;
        }
    }

    public void FixSpriteHorizontalOrientation()
    {
        if (Input.GetAxisRaw("Horizontal") == -1 && canWalk)
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1 && canWalk)
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void Move()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        //Dash controls
        if (direction.x > 0 && Input.GetKey(dash))
        {
            moveVelocity = dashSpeed;
            body.velocity = new Vector2(moveVelocity, 0);
        }
        else if (direction.x < 0 && Input.GetKey(dash))
        {
            moveVelocity = -dashSpeed;
            body.velocity = new Vector2(moveVelocity, 0);
        }
        //Move controls
        else if (direction.x > 0)
        {
            moveVelocity = moveSpeed;
            body.velocity = new Vector2(moveVelocity, 0);
        }
        else if (direction.x < 0)
        {
            moveVelocity = -moveSpeed;
            body.velocity = new Vector2(moveVelocity, 0);
        }
    }

    //Leave the construction and update methods at the end of the code, always.
    private void FixedUpdate()
    {
        this.Move();
        this.FixSpriteHorizontalOrientation();

    }

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
}