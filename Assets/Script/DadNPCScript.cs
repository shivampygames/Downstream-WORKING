using TMPro;
using UnityEngine;

public class DadNPCScript : MonoBehaviour
{

    public Animator NPCanimator;
    [SerializeField] protected Collider NPCcollider;
    [SerializeField] protected Outline NPCoutline;
    protected bool playerInBoundsToInteract;
    //protected Coroutine dialogueCoroutine;
    //public GameObject dialogueGameObject;
    //public TMP_Text speakerText;
    //public TMP_Text dialogueText;
    //public TMP_Text instructionText;
    //protected Coroutine typewriterText;
    //protected Coroutine sequenceDialogue;
    public GameObject interactTextBox;
    public TMP_Text interactText;
    //public DialogueSpriteController spriteController;

    public DialogueTextTriggerScript textTriggerScript;
    public GameManager gameManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.currentState == GameManager.GameState.backstory )
        {

        } else if (gameManager.currentState == GameManager.GameState.lvl001)
        {

            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Dad" }, new string[] { "Good morning, kiddo. Did you sleep well?", "Yeah I did!", "That's good, bud.", "How about helping us catch some fish? We can eat breakfast after." }, true, new string[] { "Left", "Right", "Left", "Left" }, new int[] { 1, 1, 3, 2 });
            }

        } else if (gameManager.currentState == GameManager.GameState.lvl002andahalf)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi" }, new string[] { "Hey kiddo :) You doing good?", "Yeah :D" }, true, new string[] { "Left", "Right" }, new int[] { 3, 1 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl002)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi" }, new string[] { "Hey kiddo :) You doing good?", "Yeah :D" }, true, new string[] { "Left", "Right" }, new int[] { 3, 1 });
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
            playerInBoundsToInteract = false;

            interactTextBox.SetActive(false);
            interactText.text = "";

            textTriggerScript.StopAllDialogue();

        }
    }

}
