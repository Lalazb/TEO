using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public GameObject playerShield;
    public float shieldTimeout;
    bool Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerShield.SetActive(false);
        shieldTimeout = 0;
        Cooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.K) && Cooldown)
        {
            Cooldown = false;
            playerShield.SetActive(true);
            StartCoroutine(TimeOut());
        }
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(15);
        playerShield.SetActive(false);
        yield return new WaitForSeconds(5);
        Cooldown = true;
    }
}
