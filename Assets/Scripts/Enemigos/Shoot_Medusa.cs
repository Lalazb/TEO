using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Medusa : MonoBehaviour
{
    public Transform player;
    public Transform shootPos;
    public float range;
    public float timeBTWShots;
    public float shootSpeedX;
    public float shootSpeedY;
    public GameObject seed;

    private float distToPlayer;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector3.Distance(transform.position, player.position);
        if(distToPlayer<=range)
        {
            if(player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                if(canShoot)
                StartCoroutine(ShootLeft());
            }
            if(canShoot)
            StartCoroutine(ShootRight());
        }
    }

     IEnumerator ShootRight()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(seed, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(shootSpeedX * Time.fixedDeltaTime, shootSpeedY * -1 * Time.fixedDeltaTime);
        canShoot = true;
    } 
    
    IEnumerator ShootLeft()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(seed, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody>().velocity = new Vector3(shootSpeedX * -1 * Time.fixedDeltaTime, shootSpeedY * -1 * Time.fixedDeltaTime);
        canShoot = true;
    }
}
