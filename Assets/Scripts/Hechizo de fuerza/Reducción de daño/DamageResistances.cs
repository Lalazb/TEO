using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Damage Resistances", menuName = "Damage Resistances")]
public class DamageResistances : ScriptableObject
{
    [System.Serializable]
    public struct Resistance
    {
        public DamageTypes damageType;
        public float percentageToTake;
    }

    public List<Resistance> resistances = new List<Resistance>();

    public int CalculateDamageWithResistance(int damage, DamageTypes damageType)
    {
        for (int i = 0; i < resistances.Count; i++)
        {
            if (resistances[i].damageType == damageType)
            {
                return (int)((damage * resistances[i].percentageToTake) / 100);
            }
        }
        return 0;
    }
}