using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private DamageResistances damageResistance;

    private void Start()
    {
        health = maxHealth;
    }

    public void DealDamage(int damage, DamageTypes damageType)
    {
        health -= damageResistance.CalculateDamageWithResistance(damage, damageType);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}

