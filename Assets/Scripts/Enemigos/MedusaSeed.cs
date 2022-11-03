using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaSeed : MonoBehaviour
{
    public float dieTime;
    public float damage;
    //public GameObject diePrefect;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Die();
    }

    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
