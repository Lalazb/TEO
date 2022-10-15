using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkMedusa : MonoBehaviour
{

    //public int Displayvidas = TeoState.vidas;
    //public TextMeshProUGUI DVidas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "teo" && TeoState.vidas > 0)
        {
            TeoState.nslow = 1;
            TeoState.vidas -= 1;
            TeoState.SavePrefs();
            Destroy(this.gameObject);
            print("Vidas restantes " + TeoState.vidas);
        }
    }
}

