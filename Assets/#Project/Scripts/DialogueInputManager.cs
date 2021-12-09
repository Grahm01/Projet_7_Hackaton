using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        // return right away if dialogue isn't playing

        // handle continuing to the next line in the dialogue when submit is pressed
        // NOTE: The 'currentStory.currentChoiecs.Count == 0' part was to fix a bug after the Youtube video was made
        if (InputManager.GetInstance().GetSubmitPressed()) //(currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed())
        {
            DialogueManager.GetInstance().ContinueStory();
        }

        if (InputManager.GetInstance().GetInteractPressed())
        {
            if (DialogueManager.GetInstance().dialogueIsPlaying == false) // makes it impossible to trigger the dialogue again = not reset the dialogue by pressing "i" until dialogue is finished
            {
                DialogueManager.GetInstance().EnterRandomDialogueMode();

            }
            else
            {
                DialogueManager.GetInstance().ContinueStory();
            }
        }

    }
}
