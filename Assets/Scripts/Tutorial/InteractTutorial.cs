using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractTutorial : MonoBehaviour
{
    [Header("Interact Key")]
    public GameObject interactTutorialCanvas;
    public Text interactKeyText;

    [HideInInspector]
    public Animator interactTutorialAnimator;

    private KeyCode interactKey;

    public void EndInteractKeyBubble()
    {
        interactTutorialAnimator.enabled = false;
        interactTutorialCanvas.SetActive(false);
    }

    public void StartInteractKeyBubble(KeyCode interactKeyFromParent)
    {
        interactKey = interactKeyFromParent;
        interactTutorialAnimator.SetBool("StayAnim", true);
            
        interactTutorialAnimator.Rebind();
        interactTutorialAnimator.Update(0f);

        interactTutorialCanvas.SetActive(true);
        interactTutorialAnimator.enabled = true;

        interactKeyText.text = "Press " + interactKey.ToString() + " to interact";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        interactTutorialAnimator = GetComponent<Animator>();
    }
}
