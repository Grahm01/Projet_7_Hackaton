using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    // [SerializeField] private TextMeshProUGUI displayNameText;
    // [SerializeField] private Animator portraitAnimator;
    // private Animator layoutAnimator;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    [HideInInspector]
    public bool dialogueIsPlaying = false;
    public List<GameObject> dialogues;


    public AudioSource musique;
    public AudioSource bo;
    public GameObject chat;
    public GameObject chien;
    public GameObject lapin;
    public GameObject lezard;

    private GameObject item;
    private GameObject item1;
    private GameObject item2;
    private GameObject item3;

    private bool chat1 = true;
    private bool chien1 = true;
    private bool lapin1 = true;
    private bool lezard1 = true;

    private bool isActive = false;
    private bool isActive1 = false;
    private bool isActive2 = false;
    private bool isActive3 = false;




    public GameObject selectedDialogue;


    private static DialogueManager instance;

    // private const string SPEAKER_TAG = "speaker";
    // private const string PORTRAIT_TAG = "portrait";
    // private const string LAYOUT_TAG = "layout";

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        bo.Play();

        //     // get the layout animator
        //     layoutAnimator = dialoguePanel.GetComponent<Animator>();

        //     // get all of the choices text 
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {


        if (dialogueText.text == "🐈 Regardons les photos du chat\n" && chat1)
        {
            isActive = true;
            Debug.Log("chat");
            Vector3 position = new Vector3(-4.32000017f, -2.50200939f, 0f);
            item = Instantiate(chat, position, Quaternion.identity);
            chat1 = false;
        }

        if (dialogueText.text != "🐈 Regardons les photos du chat\n" && isActive)
        {
            Destroy(item);
            
        }

        if (dialogueText.text == "🐕 Regardons les photos du chien\n" && chien1)
        {
            isActive1 = true;
            Debug.Log("chien");
            Vector3 position = new Vector3(-4.32000017f, -2.50200939f, 0f);
            item1 = Instantiate(chien, position, Quaternion.identity);
            chien1 = false;
        }

        if (dialogueText.text != "🐕 Regardons les photos du chien\n" && isActive1)
        {
            Destroy(item1);
            
        }


        if (dialogueText.text == "🐇 Regardons les photos des lapins\n" && lapin1)
        {
            isActive2 = true;
            Debug.Log("lapin");
            Vector3 position = new Vector3(-4.32000017f, -2.50200939f, 0f);
            item2 = Instantiate(lapin, position, Quaternion.identity);
            lapin1 = false;
        }

        if (dialogueText.text != "🐇 Regardons les photos des lapins\n" && isActive2)
        {
            Destroy(item2);
            
        }

        if (dialogueText.text == "🐉 Regardons les photos des lézards/ dragons.\n" && lezard1)
        {
            isActive3 = true;
            Debug.Log("lezard");
            Vector3 position = new Vector3(-4.32000017f, -2.50200939f, 0f);
            item3 = Instantiate(lezard, position, Quaternion.identity);
            lezard1 = false;
        }


        if (dialogueText.text != "🐉 Regardons les photos des lézards/ dragons.\n" && isActive3)
        {
            Destroy(item3);

        }

        if (dialogueText.text == "Pixie joue de la musique\n")
        {
            if (musique.isPlaying == false)
            {
                bo.Pause();
                musique.Play();
            }
        }

        if (dialogueText.text == "Merci d’avoir écouté ! La musique est une des plus grandes nourritures de l’âme. Ne l’oublie pas ! Parlons encore de musique une autre fois!\n")
        {
            Debug.Log("Unpause");
            musique.Stop();
            bo.UnPause();
        }




    }

    
    public void EnterRandomDialogueMode()
    {
        if (dialogueIsPlaying) return;
        int index = Random.Range(0, dialogues.Count);

        selectedDialogue = dialogues[index];
        DialogueTrigger dialogueTrigger = selectedDialogue.GetComponent<DialogueTrigger>();
        if (dialogueTrigger == null)
        {
            Debug.LogError($"No DialogueTrigger in gameObject \"{selectedDialogue.name}\".", gameObject);
        }
        EnterDialogueMode(dialogueTrigger.inkJSON);
    }

    public void EnterDialogueMode(TextAsset inkJSON)

    {
        if (dialogueIsPlaying) return;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        //     // reset portrait, layout, and speaker
        //     displayNameText.text = "???";
        //     portraitAnimator.Play("default");
        //     layoutAnimator.Play("right");

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }



    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            // set text for the current dialogue line
            dialogueText.text = currentStory.Continue();

            // display choices, if any, for this dialogue line
            DisplayChoices();
            // handle tags
            // HandleTags(currentStory.currentTags);
        }
        else if (currentStory.currentChoices.Count == 0)
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    // private void HandleTags(List<string> currentTags)
    // {
    //     // loop through each tag and handle it accordingly
    //     foreach (string tag in currentTags) 
    //     {
    //         // parse the tag
    //         string[] splitTag = tag.Split(':');
    //         if (splitTag.Length != 2) 
    //         {
    //             Debug.LogError("Tag could not be appropriately parsed: " + tag);
    //         }
    //         string tagKey = splitTag[0].Trim();
    //         string tagValue = splitTag[1].Trim();

    //         // handle the tag
    //         switch (tagKey) 
    //         {
    //             case SPEAKER_TAG:
    //                 displayNameText.text = tagValue;
    //                 break;
    //             case PORTRAIT_TAG:
    //                 portraitAnimator.Play(tagValue);
    //                 break;
    //             case LAYOUT_TAG:
    //                 layoutAnimator.Play(tagValue);
    //                 break;
    //             default:
    //                 Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
    //                 break;
    //         }
    //     }
    // }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        InputManager.GetInstance().RegisterSubmitPressed(); // this is specific to my InputManager script
        ContinueStory();
    }

    
}
