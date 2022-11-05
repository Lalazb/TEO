using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Tracker : MonoBehaviour
{

    public Transform target;
    public float smooth = 5f;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smooth * Time.deltaTime);
    }
}
