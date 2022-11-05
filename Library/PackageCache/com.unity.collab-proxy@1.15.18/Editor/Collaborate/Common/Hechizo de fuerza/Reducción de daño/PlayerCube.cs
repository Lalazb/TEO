using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour
{
    [SerializeField] private GameObject projectile;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, transform.position + transform.forward, transform.rotation);
        }
    }
}
