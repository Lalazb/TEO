using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mana : MonoBehaviour
{

    public int full_mana;
    int cur_mana;
    public int skill_spend = 40;

    // Start is called before the first frame update
    void Start()
    {
        cur_mana = full_mana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
