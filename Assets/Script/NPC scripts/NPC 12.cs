using TMPro;
using UnityEngine;

public class NPC12 : MonoBehaviour
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
        // Dev
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.currentState == GameManager.GameState.backstory)
        {

        }
        else if (gameManager.currentState == GameManager.GameState.lvl001)
        {

            transform.position = new Vector3(-15.15f, 0.0079f, -21.02f);
            transform.rotation = Quaternion.Euler(0, -84.82f, 0);


            canInteract = true;

            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dev" }, new string[] { "congrats u found this poorly hidden easter egg. shiv (person who made this game) is officialy the best person ever btw. -shiv" }, true, new string[] { "Left" }, new int[] { 0 });
            }

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
            canInteract = false;
        }
        else if (gameManager.currentState == GameManager.GameState.lvl005)
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
