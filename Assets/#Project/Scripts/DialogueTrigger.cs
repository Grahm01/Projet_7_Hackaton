using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;



    private void Awake()
    {

    }

    private void Update()
    {
        //if (DialogueManager.GetInstance().dialogueIsPlaying == false) // makes it impossible to trigger the dialogue again = not reset the dialogue by pressing "i" until dialogue is finished
        //{
        //    visualCue.SetActive(true);
        //    if (InputManager.GetInstance().GetInteractPressed())
        //    {
        //        DialogueManager.GetInstance().EnterRandomDialogueMode();
        //    }
        //}
        //else
        //{
        //    visualCue.SetActive(false);
        //}
    }

}
