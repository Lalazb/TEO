using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpellCooldownJump : MonoBehaviour
{
    public Image imageCooldown;
    public bool cdjbool = false;
    private bool isCooldown = false;
    
    

    //Variables for coolDownTimer
    private float cooldownTime = 1.0f;
    private float cooldownTimer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J)) //Grounded
        {
            UseSpell();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    public void checkAbility() 
    {
        RaycastHit hitInfo = new RaycastHit();
        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.cyan);
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo, 0.5f))
        {
            cdjbool = true;
        }
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
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
