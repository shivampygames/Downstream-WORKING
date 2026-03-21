using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IInteractable : MonoBehaviour
{

    protected Collider interactCollider;
    protected Outline interactOutline;
    protected bool playerInBounds;
    protected bool canInteract;
    protected bool onInteraction;
    [SerializeField] protected GameObject interactTextBox;
    [SerializeField] protected TMP_Text interactText;
    protected int boxesTouched;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        interactCollider = GetComponent<Collider>();
        interactOutline = GetComponent<Outline>();
        //interactTextBox = GameObject.FindWithTag("InteractTextBox");
        //interactText = interactTextBox.GetComponentInChildren<TMP_Text>();
        //interactTextBox = GameObject.Find(gameObject.name = "InteractTextBox");
        //interactText = interactTextBox.GetComponentInChildren<TMP_Text>();

        boxesTouched = 0;

        interactOutline.enabled = false;
        playerInBounds = false;
        interactTextBox.SetActive(false);
        interactText.text = "";

        canInteract = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
     
        if (playerInBounds && canInteract)
        {
            onInteraction = true;
            //interactText.text = "E to interact";
        } else
        {
            onInteraction = false;
            //interactText.text = "";
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.name == "Heidi" && canInteract == true)
        {
            boxesTouched++;

            if (boxesTouched > 0) {
                interactOutline.enabled = true;
                playerInBounds = true;
                onInteract();
                //Debug.Log("heidi in bounds");
            }
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        
        if (other.name == "Heidi")
        {
            boxesTouched--;
            
            if (boxesTouched <= 0) { 
                interactOutline.enabled = false;
                playerInBounds = false;
                //Debug.Log("heidi lef :(");
            }
        }
    }


    protected virtual void onInteract()
    {

    }

}
