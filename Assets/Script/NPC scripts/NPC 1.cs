using TMPro;
using UnityEngine;

public class NPC1 : MonoBehaviour
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
        // Lilith
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.currentState == GameManager.GameState.backstory )
        {

        } else if (gameManager.currentState == GameManager.GameState.lvl001)
        {
            canInteract = true;
            transform.position = new Vector3(-0.01f, 0.079f, -1.79f);
            transform.rotation = Quaternion.Euler(0, -32.4f, 0);


            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Lilith" }, new string[] { "Good morning, Heidi!" }, true, new string[] { "Left" }, new int[] { 0});
            }

        } else if (gameManager.currentState == GameManager.GameState.lvl002andahalf)
        {

            canInteract= true;
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Lilith" }, new string[] { "Good morning, Heidi!" }, true, new string[] { "Left" }, new int[] { 0 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl002)
        {
            canInteract = true;
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Lilith" }, new string[] { "Good morning, Heidi!" }, true, new string[] { "Left" }, new int[] { 0 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            canInteract = true;
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Lilith" }, new string[] { "How much fish did you catch, Heidi? I bet you got a lot!" }, true, new string[] { "Left" }, new int[] { 0 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            canInteract = false;
        } else if (gameManager.currentState == GameManager.GameState.lvl005)
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
        if (canInteract) {
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
