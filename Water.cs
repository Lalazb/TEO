using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Movement>() != null)
        {
            Movement movement = other.GetComponent<Movement>();
            movement.isSwimming = true; //REFERENCÍA AL BOOL EN MOVEMENT PARA TRUE O FALSE
            other.GetComponent<Swimming>().enabled = true;
            other.GetComponent<Movement>().enabled = false;
            other.GetComponent<Jumping>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Movement>() != null)
        {
            Movement movement = other.GetComponent<Movement>();
            movement.isSwimming = false; //REFERENCÍA AL BOOL EN MOVEMENT PARA TRUE O FALSE
            other.GetComponent<Swimming>().enabled = false;
            other.GetComponent<Movement>().enabled = true;
            other.GetComponent<Jumping>().enabled = true;
        }
    }
}
