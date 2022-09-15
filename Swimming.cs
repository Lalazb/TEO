using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//INTEGRADO A SCRIPT MOVEMENT
public class Swimming : MonoBehaviour
{
    //Movement Variables
    public float moveX;
    public float moveY;
    public float factorDown;

    //Player interactors
    private Rigidbody body;

    public void Update()
    {
        body.velocity = new Vector2(moveX, 0); //hace que se mueva en X automáticamente
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