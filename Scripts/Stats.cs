using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public GameObject playerShield;
    public float shieldTimeoutDelta;

    // Start is called before the first frame update
    void Start()
    {
        playerShield.SetActive(false);
        shieldTimeoutDelta = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            playerShield.SetActive(true);
            shieldTimeoutDelta -= 0.1f;

            Debug.Log("Shield timeout =" + shieldTimeoutDelta);
        }
        
        if (shieldTimeoutDelta == 0)
        {
            playerShield.SetActive(false);
           // shieldTimeoutDelta = shieldTimeoutDelta + 0.1f;
        }
    }
}
