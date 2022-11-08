using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellCooldown : MonoBehaviour
{
    public Image imageCooldown;
    private bool isCooldown = false;

    //Variables for coolDownTimer
    private float cooldownTime = 30.0f;
    private float cooldownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        imageCooldown.fillAmount = 0.0f;  
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.K))
        {
            UseSpell();
        }
       if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer < 0.0f)
        {
            isCooldown = false;
            imageCooldown.fillAmount = 0.0f;
        }
        else
        {
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseSpell()
    {
        if (isCooldown)
        {
            //user has clicked spell
        }
        else
        {
            isCooldown = true;
            cooldownTimer = cooldownTime;
        }
    }

}
