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

    [HideInInspector]
    public PController playerController;

    private int maxHearts = TeoState.vidas;

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
            default:
                break;
        }
    }

    public void changex2JumpIconOpacity(float value)
    {
        jumpIcon.color = new Color(jumpIcon.color.r, jumpIcon.color.g, jumpIcon.color.b, value);
    }

    public void manageHearts()
    {
        maxHearts--;
        heartIcons[maxHearts].color = 
        new Color(heartIcons[maxHearts].color.r, heartIcons[maxHearts].color.g, heartIcons[maxHearts].color.b, 0.5f);
        if(maxHearts == 0)
        {
            maxHearts += 5;
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
    }
}