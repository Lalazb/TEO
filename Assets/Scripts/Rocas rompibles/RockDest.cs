using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RockPiece"))
        {
            Destroy(other.gameObject,1f);
        }
    }
}
