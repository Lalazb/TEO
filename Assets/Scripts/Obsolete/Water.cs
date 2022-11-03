using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<PController>().isSwiming = true;
        }
        /*if (other.CompareTag("Player"))
        {
            PController pcontroller = other.GetComponent<PController>();
            pcontroller.isSwimming = true; //REFERENC�A AL BOOL EN MOVEMENT PARA TRUE O FALSE
            other.GetComponent<Swimming>().enabled = true;
            other.GetComponent<PController>().enabled = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.GetComponent<PController>().isSwiming = false;
        }
        /*if (other.CompareTag("Player"))
        {
            PController pcontroller = other.GetComponent<PController>();
            pcontroller.isSwimming = false; //REFERENC�A AL BOOL EN MOVEMENT PARA TRUE O FALSE
            other.GetComponent<Swimming>().enabled = false;
            other.GetComponent<PController>().enabled = true;
        }*/
    }
}
