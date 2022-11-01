using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkMedusa : MonoBehaviour
{
    int type = 0;
    //public int Displayvidas = TeoState.vidas;
    //public TextMeshProUGUI DVidas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && TeoState.vidas > 0)
        {
            TeoState.nslow = 1;
            TeoState.vidas -= 1;
            GameManager.gmInstance.manageHearts(type);
            TeoState.SavePrefs();
            Destroy(this.gameObject);
            print("Vidas restantes " + TeoState.vidas);
        }
    }
}

