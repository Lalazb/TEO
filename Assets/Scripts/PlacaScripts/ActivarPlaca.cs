using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPlaca : MonoBehaviour
{

    public LayerMask maskPlaca;
    public Rigidbody rigido;
    public GameObject Escudo;
    public bool move;
    public bool check;
    bool activo;

    // Start is called before the first frame update
    void Start()
    {
        activo = true;
    }

    // Update is called once per frame
    void Update()
    {
        move = Escudo.gameObject.activeSelf;
        if (move && !check)
        {
            rigido.isKinematic = false;
        }
        if (!move)
        {
            rigido.isKinematic = true;
        }
        if (Physics.Raycast(transform.position, Vector3.down, 10, maskPlaca) && activo)
        {
            check = true;
            activo = false;
            StartCoroutine(placon());
        }
    }

    IEnumerator placon()
    {
        yield return new WaitForSeconds(1);
        plataforma.contpuzz += 1;
        rigido.isKinematic = true;
    }
}
