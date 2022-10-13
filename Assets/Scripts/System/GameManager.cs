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

    /// Awake is called when the script instance is being loaded.
    private void Awake()
    {
        gmInstance = this;
        playerController = FindObjectOfType<PController>();
    }
}