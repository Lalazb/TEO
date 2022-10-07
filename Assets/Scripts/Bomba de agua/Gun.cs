using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
    //
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firepoint;

    [SerializeField] private GameObject chargedProjectile;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    private bool isCharging;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && chargeTime < 2) 
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(projectile, firepoint.position, firepoint.rotation);
            chargeTime = 0;
        } else if(Input.GetKeyUp(KeyCode.F) && chargeTime >= 2)
        {
            ReleaseCharge();
        }
    }


    void ReleaseCharge()
    {
        Instantiate(chargedProjectile, firepoint.position, firepoint.rotation);
        isCharging = false;
        chargeTime = 0;
    }
}
