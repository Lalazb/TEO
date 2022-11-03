using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gmInstance;

    [Header("Player Data")]
    public Image[] heartIcons = new Image[5];
    public Image jumpIcon;
    public Image bombIcon;
    public Image shieldIcon;

    [HideInInspector]
    public PController playerController;
    [HideInInspector]
    public Gun waterBomb;
    [HideInInspector]
    public Shield shield;

    private int maxHearts = TeoState.vidas;
    private int varH = 5;

    public void unlockQuestReward(string reward)
    {
        switch (reward)
        {
            case "x2Jump":
            {
                jumpIcon.gameObject.SetActive(true);
                playerController.hability = true;
                break;
            }
            case "waterBomb":
            {
                if(waterBomb != null)
                {
                    bombIcon.gameObject.SetActive(true);
                    waterBomb.enabled = true;
                }
                break;
            }
            case "catShield":
             {
                if (shield != null)
                {
                    shieldIcon.gameObject.SetActive(true);
                    shield.enabled = true;
                }
                break;
             }
            default:
            break;
        }
    }

    public void changex2JumpIconOpacity(float value)
    {
        jumpIcon.color = new Color(jumpIcon.color.r, jumpIcon.color.g, jumpIcon.color.b, value);
    }

    public void manageHearts(int type)
    {
        if (type == 0)
        {
            maxHearts--;
            varH--;
            heartIcons[maxHearts].color =
            new Color(heartIcons[maxHearts].color.r, heartIcons[maxHearts].color.g, heartIcons[maxHearts].color.b, 0.5f);
        }
        else if (type == 1)
        {
            maxHearts++;
            heartIcons[varH].color =
            new Color(heartIcons[varH].color.r, heartIcons[varH].color.g, heartIcons[varH].color.b, 1.0f);
            varH++;
        }

        if (maxHearts == 0)
        {
            maxHearts += 4;
            varH = 4;
            for(int i = 0; i < maxHearts; i++)
            {
                heartIcons[i].color = 
                new Color(heartIcons[i].color.r, heartIcons[i].color.g, heartIcons[i].color.b, 1.0f);
            }
            //Debug.Log(maxHearts);          
        }        
    }

    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        gmInstance = this;
        playerController = FindObjectOfType<PController>();
        waterBomb = FindObjectOfType<Gun>();
        shield = FindObjectOfType<Shield>();
    }
}