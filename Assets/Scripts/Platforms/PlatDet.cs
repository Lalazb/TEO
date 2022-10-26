using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatDet : MonoBehaviour
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
       
        //move left 
        if (detected && detectedPlayer.position.x < transform.position.x)
        {
            transform.Translate(factor * (-1f), 0f, 0f);
        }
      
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "PlatMove")
        {
            detected = true;
            detectedPlayer = other.transform;
            //GetComponent<PController>().moving = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        detected = false;
        //GetComponent<PController>().moving = true;
    }

}
