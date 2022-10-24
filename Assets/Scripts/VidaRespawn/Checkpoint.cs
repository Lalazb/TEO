using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    float PosI = 0f;
    float PosN = 0f;

    private void OnTriggerEnter(Collider other)
    {
        PosI = TeoState.position.z;
        PosN = this.transform.position.z;
        if (other.tag == "Player" && PosN > PosI)
        {
            if (this.tag == "hcheck")
            {
                TeoState.hposition = this.transform.position;
                TeoState.SavePrefs();
                print("Ultimo checkpoint" + TeoState.hposition);
                Material material = gameObject.GetComponent<MeshRenderer>().material;
                material.color = Color.green;
                print(PosI + "seg" + PosN);
            }
            else
            {
                TeoState.position = this.transform.position;
                TeoState.SavePrefs();
                print("Ultimo checkpoint" + TeoState.position);
                Material material = gameObject.GetComponent<MeshRenderer>().material;
                material.color = Color.green;
                print(PosI + "seg" + PosN);
            }
        }
    }
}
