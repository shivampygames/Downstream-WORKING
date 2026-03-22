using System.Collections;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class DialogueTextTriggerScript : MonoBehaviour
{
    public Coroutine dialogueCoroutine;
    public GameObject dialogueGameObject;
    public TMP_Text speakerText;
    public TMP_Text dialogueText;
    public TMP_Text instructionText;
    public Coroutine typewriterText;
    public Coroutine sequenceDialogue;
    public GameObject interactTextBox;
    public TMP_Text interactText;
    public DialogueSpriteController spriteController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogueGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScriptTriggered(string[] speakerListX, string[] dialogueListX, bool isEndingDialogueListX, string[] SpriteLeftRightNeitherX, int[] whichSpriteX)
    {
        if (sequenceDialogue == null) {

            spriteController.rightSprite.sprite = spriteController.rightSprites[0];
            spriteController.cinematic.sprite = spriteController.cinematicSprites[0];
            spriteController.cinematicBackground.sprite = spriteController.cinematicSprites[0];
            spriteController.leftSprite.sprite = spriteController.leftSprites[0];
            
            sequenceDialogue = StartCoroutine(SequentialDialogue(speakerListX, dialogueListX, isEndingDialogueListX, SpriteLeftRightNeitherX, whichSpriteX));
        }

    }

    public void StopAllDialogue()
    {
        if (sequenceDialogue != null) 
        { 
            StopCoroutine(sequenceDialogue); 
        }
        if (dialogueCoroutine != null) 
        { 
            StopCoroutine(dialogueCoroutine); 
        }
        if (typewriterText != null)
        {
            StopCoroutine(typewriterText);
        }

        sequenceDialogue = null;
        dialogueCoroutine = null;
        typewriterText = null;

        dialogueGameObject.SetActive(false);
    }

    public IEnumerator SequentialDialogue(string[] speakerList, string[] dialogueList, bool isEndingDialogueList, string[] SpriteLeftRightNeither, int[] whichSprite)
    {
        
        interactTextBox.SetActive(false);
        int speakerListLength = speakerList.Length;
        int dialogueListLength = dialogueList.Length;

        dialogueGameObject.SetActive(true);
        yield return null;


        for (int i = 0; i < speakerListLength; i++)
        {
            if (dialogueCoroutine != null)
            {
                StopCoroutine(dialogueCoroutine);
                dialogueCoroutine = null;
            }

            if (SpriteLeftRightNeither[i] == "Left")
            {
                spriteController.changeLeftSprite(whichSprite[i]);
            }
            else if (SpriteLeftRightNeither[i] == "Right")
            {
                spriteController.changeRightSprite(whichSprite[i]);
            } else if (SpriteLeftRightNeither[i] == "Cinematic")
            {
                spriteController.changeCinematicSprites(whichSprite[i]);
            }
            else
            {
                spriteController.clearSprites();
            }

            yield return dialogueCoroutine = StartCoroutine(PlayDialogue(speakerList[i], dialogueList[i]));


        }

        yield return new WaitForSeconds(0.1f);
        if ((SpriteLeftRightNeither[0] == "Cinematic") || (SpriteLeftRightNeither[0] == "None"))
        {
            interactTextBox.SetActive(false);
        } else
        {
            interactTextBox.SetActive(true);
        }
            StopAllDialogue();

    }

    public IEnumerator PlayDialogue(string speaker, string dialogue)
    {
        speakerText.text = speaker;
        dialogueText.text = dialogue;

        instructionText.text = "Click E to continue >>";

        dialogueText.maxVisibleCharacters = 0;
        dialogueGameObject.SetActive(true);
        if (typewriterText == null)
        {
            typewriterText = StartCoroutine(TypewriterCoroutine(dialogue));
        }
        else
        {

            StopCoroutine(typewriterText);
            typewriterText = null;
            typewriterText = StartCoroutine(TypewriterCoroutine(dialogue));
        }

        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.E)) == true);
        //Debug.Log("[close dialogue]"); // ends the text coroutine too and hides UI
        if (typewriterText == null)
        {
            dialogueGameObject.SetActive(false);
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;
            yield break;
        }
        else
        {
            StopCoroutine(typewriterText);
            typewriterText = null;
            dialogueText.maxVisibleCharacters = dialogueText.textInfo.characterCount;

            yield return new WaitForSeconds(0.2f);
            yield return new WaitUntil(() => (Input.GetKeyDown(KeyCode.E)) == true);

            
            StopCoroutine(dialogueCoroutine);
            dialogueCoroutine = null;



        }

        yield break;


    }

    public IEnumerator TypewriterCoroutine(string dialogue)
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
