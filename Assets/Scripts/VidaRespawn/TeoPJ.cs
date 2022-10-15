using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeoPJ : MonoBehaviour
{
    public int Displayvidas = TeoState.vidas;
    public TextMeshProUGUI DVidas;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = TeoState.position;
    }

    // Update is called once per frame
    void Update()
    {
        Displayvidas = TeoState.vidas;
        DVidas.text = Displayvidas.ToString();
        if (TeoState.vidas == 0)
        {
            this.transform.position = TeoState.hposition;
            TeoState.vidas += 5;
            //respawn = true;
        }
        else if (TeoState.resp == 1)
        {
            this.transform.position = TeoState.position;
            TeoState.resp = 0;
        }
    }
}

