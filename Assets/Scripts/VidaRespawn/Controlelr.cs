using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlelr : MonoBehaviour
{
    public float speed = 10;
    public float force = 5;
    public float distancia = 1;
    public LayerMask layerMask;
    Rigidbody rb;
    public float NT = 0f;
    public float resta = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NT > 0)
        {
            speed = 5;
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(horizontal * transform.forward * speed * Time.deltaTime);
            if (Input.GetButton("Jump") && Grounded())
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            NT -= resta * Time.deltaTime;
        }
        else
        {
            speed = 10;
            float horizontal = Input.GetAxis("Horizontal");
            transform.Translate(horizontal * transform.forward * speed * Time.deltaTime);
            if (Input.GetButton("Jump") && Grounded())
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
        if (TeoState.nslow == 1)
        {
            NT = 4;
            TeoState.nslow = 0;
            TeoState.SavePrefs();
        }


    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distancia, layerMask);
    }
}

