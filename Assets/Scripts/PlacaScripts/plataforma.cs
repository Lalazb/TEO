using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class plataforma : MonoBehaviour
{

    Vector3 posi;
    public int NumPuzzle;
    public static int contpuzz;
    public int ayuda;
    public float top;
    public float bott;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ayuda = contpuzz;
        posi = this.transform.position;
        if (contpuzz == NumPuzzle)
        {
            if (posi.y<=top)
            {
                this.transform.position += new Vector3(0,0.5f,0)*Time.deltaTime;
            }
        }
        else if (contpuzz != NumPuzzle)
        {
            if (posi.y >= bott)
            {
                this.transform.position += new Vector3(0, -0.5f, 0) * Time.deltaTime;
            }
        }
    }
}
