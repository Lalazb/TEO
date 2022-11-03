using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Lalo : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private int damage;
    [SerializeField] private DamageTypes damageType;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<EnemyHealth>() != null)
        {
            collision.collider.GetComponent<EnemyHealth>().DealDamage(damage, damageType);
        }
        Destroy(gameObject);
    }
}
