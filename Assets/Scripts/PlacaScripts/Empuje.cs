using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    public float restado;
    public Collider rocaasignada;
    public bool activo;

    // Update is called once per frame
    void Update()
    {
        activo = true;
    }

    private void OnTriggerEnter(Collider rocaActiva)
    {
        if (rocaActiva == rocaasignada && activo)
        {
            this.transform.position -= new Vector3(0, restado, 0);
            activo = false;
        }
    }

}
