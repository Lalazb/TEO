using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Medusa")
        {
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
