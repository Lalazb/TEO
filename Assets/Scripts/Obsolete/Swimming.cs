using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INTEGRAR A PCONTROLLER
public class Swimming : MonoBehaviour
{
    //Movement Variables
    public float moveX = 5f;
    public float moveY = 5f;

    //Player interactors
    private Rigidbody body;

    public void Update()
    {
        //body.velocity = new Vector2(moveX, 0); //hace que se mueva en X autom�ticamente
        //Debug.Log("avanza");

        //Move controls
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //body.AddForce(Vector3.up*moveY, ForceMode.Impulse);
            body.velocity = new Vector2(moveX, moveY);
            Debug.Log("button down");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //body.AddForce(Vector3.down * moveY*factorDown, ForceMode.Impulse);
            body.velocity = new Vector2(moveX, 0);
            Debug.Log("button up");
        }
    }
    
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
}