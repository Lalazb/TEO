using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
     Rigidbody piecesRB;

    GameObject rock;

    int count = 3;

     GameObject bomb;
    float distanceDir;
    float distanceAbs;
    float distZ;
    float distDirZ;
    Transform Pos;

    float impactZone = 20f;



    // Start is called before the first frame update
    void Start()
    {
        piecesRB = GetComponentInParent<Rigidbody>();

        rock = GameObject.FindWithTag("RockPiece");

        piecesRB.isKinematic = true;

        bomb = GameObject.Find("Water_Bomb");

        Pos = GetComponentInParent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceDir = Pos.transform.position.y - bomb.transform.position.y;
        distanceAbs = Mathf.Abs(distanceDir);

        distDirZ = Pos.transform.position.z - bomb.transform.position.z;
        distZ = Mathf.Abs(distDirZ);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WaterBomb")
        {
            count--;
            if (count<=0)
            {
                if (distanceAbs < impactZone && distZ < impactZone)
                {
                    piecesRB.AddForce(transform.right * (420f));

                }
             

                piecesRB.isKinematic = false;
                //piecesRB.detectCollisions = false;


            }
           
        }
    }
}
