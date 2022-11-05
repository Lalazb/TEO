using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocarMedusa : MonoBehaviour
{
    int type = 0;
    //public int Displayvidas = TeoState.vidas;
    //public TextMeshProUGUI DVidas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TeoState.vidas > 0)
        {
            TeoState.vidas -= 1;
            GameManager.gmInstance.manageHearts(type);
            TeoState.SavePrefs();
            print("Vidas restantes " + TeoState.vidas);
        }
    }
}
