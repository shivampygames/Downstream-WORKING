using TMPro;
using UnityEngine;

public class NPC6 : MonoBehaviour
{

    public Animator NPCanimator;
    [SerializeField] protected Collider NPCcollider;
    [SerializeField] protected Outline NPCoutline;
    protected bool playerInBoundsToInteract;
    public GameObject interactTextBox;
    public TMP_Text interactText;

    public DialogueTextTriggerScript textTriggerScript;
    public GameManager gameManager;

    bool canInteract = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Ellie
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.currentState == GameManager.GameState.backstory)
        {

        }
        else if (gameManager.currentState == GameManager.GameState.lvl001)
        {

            transform.position = new Vector3(-0.98f, 0.0079f, -28.23f);
            transform.rotation = Quaternion.Euler(0, 98.312f, 0);


            canInteract = false;

        }
        else if (gameManager.currentState == GameManager.GameState.lvl002andahalf)
        {

            canInteract = false;
        }
        else if (gameManager.currentState == GameManager.GameState.lvl002)
        {
            canInteract = false;
        }
        else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            canInteract = false;

        }
        else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            canInteract = true;

            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Ellie", "Ellie", "Dev", "Dev", "Ellie", "" }, new string[] { "There's something... with this fish.", "Why does it look like this? It's almost like the same disease from the plants.", "That... is odd... you're right, it does look like the plant disease.", "It's probably just a one-time occurence. Throw it back into the water.", "Oh, I hope it's a one time occurence. Okay.", "[Everyone scatters again.]" }, true, new string[] { "Left", "Left", "Left", "Left", "Left", "None" }, new int[] { 8, 9, 13, 15, 8, 0 });

            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl005)
        {
            canInteract = true;

            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Ellie", "Ellie", "Leo", "Eve", "Ellie", "" }, new string[] { "There's something... with this fish.", "Why does it look like this?", "That... is odd...", "It's probably just sick. Throw it back into the water.", "Oh, poor thing. Okay.", "[Everyone scatters again.]" }, true, new string[] { "Left", "Left", "Left", "Left", "Left", "None" }, new int[] { 0, 0, 0, 0, 0, 0 });
                
            }

        }
        else if (gameManager.currentState == GameManager.GameState.lvl006)
        {
            canInteract = false;

        }


    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (canInteract)
        {

            if (other.name == "Heidi")
            {
                NPCoutline.enabled = true;
                playerInBoundsToInteract = true;
                interactText.text = "E to interact";
                interactTextBox.SetActive(true);



            }

        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (canInteract)
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

}
