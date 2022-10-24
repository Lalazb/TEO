using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TeoState.vidas > 1)
        {
            TeoState.vidas -= 1;
            TeoState.resp = 1;
            TeoState.SavePrefs();
            print("Vidas restantes " + TeoState.vidas);
        }
        else if (other.tag == "Player" && TeoState.vidas == 1)
        {
            TeoState.vidas -= 1;
            TeoState.SavePrefs();
            print("Vidas restantes " + TeoState.vidas);
        }
    }
}

