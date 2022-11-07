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
    [SerializeField] private float sizeGrow;
    private bool isCharging;
    public float scaleChange = 0.01f;
    public float waitFor;
    [SerializeField] private GameObject growth;

    Animator animator;

    bool cooldown = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && chargeTime < 2 && cooldown)  //bomba gde
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargeTime += Time.deltaTime * chargeSpeed;
                GameObject newgrowth = Instantiate(growth, firepoint.position, firepoint.rotation);
                float scale = scaleChange * chargeTime * sizeGrow;
                newgrowth.transform.localScale += new Vector3 (scale, scale, scale);
                Destroy(newgrowth, 0.1f);
            }
        }

        if (Input.GetKeyDown(KeyCode.J) && cooldown) //bomba chica
        {
            Instantiate(projectile, firepoint.position, firepoint.rotation);
            chargeTime = 0;
            cooldown = false;
            StartCoroutine(TimeOut(waitFor));
        } else if(Input.GetKeyUp(KeyCode.J) && chargeTime >= 2 )
        {
            ReleaseCharge();
        }

    }


    void ReleaseCharge()
    {
        Instantiate(chargedProjectile, firepoint.position, firepoint.rotation);
        isCharging = false;
        chargeTime = 0;
        cooldown = false;
        StartCoroutine(TimeOut(waitFor));
    }

    IEnumerator TimeOut(float waitFor)
    {
        yield return new WaitForSeconds(waitFor);
        cooldown = true;
    }
}
