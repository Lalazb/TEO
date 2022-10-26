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

    //rotation
    public GameObject target;
    Vector2 dir;



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
        if (detected && detectedPlayer.position.x > transform.position.x &&  transform.rotation.z > 0 && transform.rotation.z < 91)
        {
            transform.Translate(factor*1.3f, factor*1.3f, 0f);
        }
        //move right and down
        if (detected && detectedPlayer.position.x > transform.position.x && transform.rotation.z < 0 && transform.rotation.z > -91)
        {
            transform.Translate(factor*1.3f, factor*(-1.3f), 0f);
        }

        Vector2 targetPos = detectedPlayer.transform.position;
        dir = targetPos - (Vector2)transform.position;

        if (detected)
        {
            transform.right = dir;
        }
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
        }
        if (other.tag == "EndofLine" && detected)
        {
            detected = false;
            detectedPlayer = other.transform;
        }
    }

    

}
