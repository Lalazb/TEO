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
        if(detected && detectedPlayer.position.z > transform.position.z)
        {
            transform.Translate(0f, 0f, factor);
        }
        //move right and up
        if (detected && detectedPlayer.position.z > transform.position.z && detectedPlayer.position.y > transform.position.y)
        {
            transform.Translate(0f, factor, factor);
        }
        //move right and down
        if (detected && detectedPlayer.position.z > transform.position.z && detectedPlayer.position.y < transform.position.y)
        {
            transform.Translate(0f, factor*(-1f), factor);
        }


        // /*

        //move left (just for proggress demo)
        if (detected && detectedPlayer.position.z < transform.position.z)
        {
            transform.Translate(0f, 0f, factor * (-1f));
        }
        //move left & up (just for proggress demo)
        if (detected && detectedPlayer.position.z < transform.position.z && detectedPlayer.position.y > transform.position.y)
        {
            transform.Translate(0f, factor, factor * (-1f));
        }
        //move left & down (just for proggress demo)
        if (detected && detectedPlayer.position.z < transform.position.z && detectedPlayer.position.y < transform.position.y)
        {
            transform.Translate(0f, factor*(-1f), factor * (-1f));
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
