using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    // private bool playerInRange;

    private void Awake() 
    {
        // playerInRange = false;
        // visualCue.SetActive(false);
    }

    private void Update() 
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying) // makes it impossible to trigger the dialogue again = not reset the dialogue by pressing "i" until dialogue is finished
        {
            visualCue.SetActive(true);
            if (InputManager.GetInstance().GetInteractPressed()) 
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else 
        {
            visualCue.SetActive(false);
        }
    }

    // private void OnMouseDown() 
    // {
    //     if (collider.gameObject.tag == "Player")
    //     {
    //         playerInRange = true;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D collider) 
    // {
    //     if (collider.gameObject.tag == "Player")
    //     {
    //         playerInRange = false;
    //     }
    // }
}