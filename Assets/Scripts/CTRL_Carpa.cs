using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTRL_Carpa : MonoBehaviour
{
    //detection
    bool detected;
    //move
    public float swimSpeed;
    Transform detectedPlayer;


    // Start is called before the first frame update
    void Start()
    {
        detected = false;

    }

    
    void FixedUpdate()
    {
        float factor = swimSpeed * Time.deltaTime;
        //move right
        if(detected && detectedPlayer.position.x > transform.position.x)
        {
            transform.Translate(factor, 0f, 0f);
        }
        //move right and up
        if (detected && detectedPlayer.position.x > transform.position.x && detectedPlayer.position.y > transform.position.y)
        {
            transform.Translate(factor, factor, 0f);
        }
        //move right and down
        if (detected && detectedPlayer.position.x > transform.position.x && detectedPlayer.position.y < transform.position.y)
        {
            transform.Translate(factor, factor*(-1f), 0f);
        }


        // /*

        //move left (just for proggress demo)
        if (detected && detectedPlayer.position.x < transform.position.x)
        {
            transform.Translate(factor * (-1f), 0f, 0f);
        }
        //move left & up (just for proggress demo)
        if (detected && detectedPlayer.position.x < transform.position.x && detectedPlayer.position.y > transform.position.y)
        {
            transform.Translate(factor * (-1f), factor, 0f);
        }
        //move left & down (just for proggress demo)
        if (detected && detectedPlayer.position.x < transform.position.x && detectedPlayer.position.y < transform.position.y)
        {
            transform.Translate(factor * (-1f), factor*(-1f), 0f);
        }

        // */



    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
        }
    }

}
