using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapaNeph : MonoBehaviour
{
    public float PosT = 0f;
    public float Mover = 6f;
    public Vector3 rotar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PosT >= 180)
        {
            rotar = new Vector3(0, 0, 0);
            this.transform.Rotate(rotar);
            StartCoroutine(Pauson());
            PosT = 0;
        }
        else if (PosT >= 0 && PosT < 90)
        {
            PosT += Mover * Time.deltaTime;
            rotar = new Vector3(0, 0, Mover);
            this.transform.Rotate(rotar * Time.deltaTime);
        }
        else
        {
            PosT += Mover * Time.deltaTime;
            rotar = new Vector3(0, 0, Mover);
            this.transform.Rotate(-rotar * Time.deltaTime);

        }

    }

    IEnumerator Pauson()
    {
        Mover = 0f;
        yield return new WaitForSeconds(5);
        Mover = 6f;
    }
}
