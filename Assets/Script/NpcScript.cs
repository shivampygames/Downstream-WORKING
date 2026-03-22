using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditor;

public class NpcScript : MonoBehaviour
{

    public Animator NPCanimator;
    protected Collider NPCcollider;
    protected Outline NPCoutline;
    protected bool playerInBoundsToInteract;
    protected Coroutine dialogueCoroutine;
    public GameObject dialogueGameObject;
    public TMP_Text speakerText;
    public TMP_Text dialogueText;
    public TMP_Text instructionText;
    protected Coroutine typewriterText;
    protected Coroutine sequenceDialogue;
    public GameObject interactTextBox;
    public TMP_Text interactText;
    public DialogueSpriteController spriteController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        NPCcollider = GetComponent<Collider>();
        NPCoutline = GetComponent<Outline>();

        NPCoutline.enabled = false;
        playerInBoundsToInteract = false;
        interactText.text = "";
        interactTextBox.SetActive(false);
        

        dialogueGameObject.SetActive(false);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        if (playerInBoundsToInteract == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("hey kiddo :)");
                if (dialogueCoroutine == null) {
                    //dialogueCoroutine = StartCoroutine(PlayDialogue("Dad", "hey kiddo :) you doing okay?", true));
                    sequenceDialogue = StartCoroutine(SequentialDialogue(new string[] {"Dad", "Heidi", "Dad", "Dad"}, new string[] { "hey kiddo :) you doing good?", "yeah! :DDDDD im gonna go play now,", "okay, stay safe, it's getting dark out", ",,,oh, and be back before dinner"}, true, new string[] { "Left", "Right", "Left", "Left" }, new int[] { 1, 1, 3, 2 }));
                    NPCanimator.SetTrigger("waving");
                }
            }
        }

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "Heidi")
        {
            NPCoutline.enabled = true;
            playerInBoundsToInteract = true;
            interactText.text = "E to interact";
            interactTextBox.SetActive(true);


        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.name == "Heidi")
        {
            NPCoutline.enabled = false;

            interactTextBox.SetActive(false);
            interactText.text = "";

            playerInBoundsToInteract = false;
            if (dialogueCoroutine != null) { 
                StopCoroutine(dialogueCoroutine);
                dialogueCoroutine = null;
                //Debug.Log("[close dialogue");
                dialogueGameObject.SetActive(false);
            }
        }
    }

    protected virtual IEnumerator SequentialDialogue(string[] speakerList, string[] dialogueList, bool isEndingDialogueList, string[] SpriteLeftRightNeither, int[] whichSprite)
    {
        interactTextBox.SetActive(false);
        int speakerListLength = speakerList.Length;
        int dialogueListLength = dialogueList.Length;
        dialogueGameObject.SetActive(true);

        for (int i = 0; i < speakerListLength; i++) {
            if (dialogueCoroutine != null)
            {
                StopCoroutine (dialogueCoroutine);
                dialogueCoroutine = null;
            }

            if (SpriteLeftRightNeither[i] == "Left")
            {
                spriteController.changeLeftSprite(whichSprite[i]);
            }
            else if (SpriteLeftRightNeither[i] == "Right")
            {
                spriteController.changeRightSprite(whichSprite[i]);
            }
            else
            {
                spriteController.clearSprites();
            }

            yield return dialogueCoroutine = StartCoroutine(PlayDialogue(speakerList[i], dialogueList[i], isEndingDialogueList));

            
        }

        interactTextBox.SetActive(true);
        StopCoroutine(sequenceDialogue);
        sequenceDialogue = null;
        yield break;

    }

    protected virtual IEnumerator PlayDialogue(string speaker, string dialogue, bool isEndingDialogue)
    {
        //Debug.Log(dialogue);

        speakerText.text = speaker;
        dialogueText.text = dialogue;

        if (isEndingDialogue)
        {
            instructionText.text = "Click E to continue >>";
        }
        else
        {
            instructionText.text = "Click E to continue >>";
        }

        dialogueText.maxVisibleCharacters = 0;
        dialogueGameObject.SetActive(true);
        if (typewriterText == null) { 
        typewriterText = StartCoroutine(TypewriterCoroutine(dialogue));
        } else
        {

            StopCoroutine(typewriterText);
            typewriterText = null;
            typewriterText = StartCoroutine(TypewriterCoroutine(dialogue));
        }

            yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.E)) == true);
        //Debug.Log("[close dialogue]"); // ends the text coroutine too and hides UI
        if (typewriterText == null) { 
            dialogueGameObject.SetActive(false);
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
            yield break;
        } else
        {
            StopCoroutine(typewriterText);
            typewriterText = null;
            dialogueText.maxVisibleCharacters = dialogueText.textInfo.characterCount;

            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.E)) == true);

            if (isEndingDialogue)
            {
                dialogueGameObject.SetActive(false);
            }
            else
            {
            }
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
            


        }

            yield break;
    }

    protected virtual IEnumerator TypewriterCoroutine(string dialogue)
    {

        dialogueText.ForceMeshUpdate();
        int totalCharacters = dialogueText.textInfo.characterCount;

        for (int i = 0; i <= totalCharacters; i++)
        {
            dialogueText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(0.02f);
        }

        StopCoroutine(typewriterText);
        typewriterText = null;
        yield break;

    }


}
