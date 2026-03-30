using TMPro;
using UnityEngine;

public class DadNPCScript : MonoBehaviour
{

    public Animator NPCanimator;
    [SerializeField] protected Collider NPCcollider;
    [SerializeField] protected Outline NPCoutline;
    protected bool playerInBoundsToInteract;
    public GameObject interactTextBox;
    public TMP_Text interactText;

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
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Dad", "" }, new string[] { "Good morning, kiddo. Did you sleep well?", "Yeah I did!", "That's good, bud.", "How about helping us catch some fish? We can eat breakfast after.", "<color=#E55735>((FACT: Approximately 10-12% of our world's population depends on aquaculture (fishing) for their livelihoods. In some low-income coastal regions, fishing is the primary economic activity and a critical tool for poverty reduction.))</color>" }, true, new string[] { "Left", "Right", "Left", "Left", "None" }, new int[] { 1, 1, 3, 2, 0 });
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
        } else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad" }, new string[] { "What are you doing here bud?", "I just came to say hi :)", "I see. Well, Hi there!" }, true, new string[] { "Left", "Right", "Left" }, new int[] { 2, 1, 3 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad" }, new string[] { "What are you doing here bud?", "I just came to say hi :)", "I see. Well, Hi there!" }, true, new string[] { "Left", "Right", "Left" }, new int[] { 2, 1, 3 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl005)
        {
            
        }
        else if (gameManager.currentState == GameManager.GameState.lvl006)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "There you are! Ready for dinner?" }, true, new string[] { "Left" }, new int[] { 3 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl007)
        {
            
        }
        else if (gameManager.currentState == GameManager.GameState.lvl008)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Heidi", "Dad", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "" }, new string[] {"Morning Dad!", "Hey, kiddo.", "...I have news.", "Everyone's been out fishing since this morning. And... there have been lots of fish with the disease... since we started today.", "How is it spreading to more fish?", "That's what we're trying to find out. Why don't you go and try to catch some fish for now? I'll keep you updated.", "OK.", "Alright, kiddo. Just ... it might be harder than it's been so far, since some of the fish are diseased. But I know you're doing your best, no matter what.", "Yes, Dad. I won't let anyone in that city starve.", "...Oh. You know that's not your burden to worry about, Heidi-", "[You left.]", "<color=#E55735>((FACT: When animals get contaminated with chemicals, it affects the rest of the food web and the rest of the ecosystem.</color>", "<color=#E55735>Bioaccumulation is when animals absorb a lot of chemicals into their bodies.  </color>" }, true, new string[] { "Right", "Left", "Left", "Left", "Right", "Left", "Right", "Left", "Right", "Left", "None" }, new int[] { 2, 1, 4, 5, 4, 7, 8, 3, 4, 6, 0 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl009)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
                {
                    textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "It's time to eat, Heidi!" }, true, new string[] { "Left" }, new int[] { 1 });
                }
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl011)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "", "Dad", "Dad", "", "", "Dad", "Heidi", "Dad" }, new string[] { "Hi, Heidi! Good morn-", "[there's a rustling in the bushes.]", "........", "Woah! That's-", "[A huge, unnaturally white-haired deer lifts its head. It looks to be covered in the same disease as the fish was.]", "[It bounds away back into the forest, though there's a noticable limp to its run.]", "That was...", "Was that deer diseased too, Dad?", "It looks like it... I'll have to go tell the others about that now. Anyway, you did good yesterday. Make sure to keep trying to stock up on fish, kiddo."}, true, new string[] { "Left", "None", "Left", "Left", "Left", "Left", "Left", "Right", "Left" }, new int[] { 3, 0, 4, 6, 10, 10, 6, 5, 7});
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl012)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad" }, new string[] { "Hungry, kiddo?", "Did we find out why the deer was like that?", "Well, someone noticed a bird turning diseased after it tried to eat one of the bad fish.", "We can only assume something similar happened to the deer.", "Will the rest of the forest be okay?", "I don't know, bud. Why don't we continue talking inside?" }, true, new string[] { "Left", "Right", "Left", "Left", "Right", "Left" }, new int[] { 3, 4, 5, 7, 9, 3 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl014)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Heidi", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Dad", "Dad", "Dad", "Heidi", "Dad" }, new string[] { "Dad, why is the sky... red...? And the air is thick...?", "We have a guess based on the last time we visited the farmers.", "Those guys don't just put pesticides into the soil. They spray it in the air too.", "Is that why the air is so polluted?", "Most likely, yes. Not only that but, there's way more diseased fish than there was yesterday. We think it's beacause of the rain. It got so much worse after it rained.", "What did the rain do?", "Probably made their chemicals wash into our river a little bit more.", "...We're going to go over and talk to them about it.", "It's supposed to rain again tonight. We're going to ask them to not put anything in the soil at least for today, or... whenever it rains.", "You wanna come with us when we visit them this evening?", "Yes, please!", "Alright. For now, though, get back to work, kiddo."  }, true, new string[] { "Right", "Left", "Left", "Right", "Left", "Right", "Left", "Left", "Left", "Left", "Right", "Left" }, new int[] { 4, 7, 5, 6, 4, 4, 7, 6, 5, 3, 3, 1 }); // the 8th one broken
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl015)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "Are you ready to go visit them, Heidi?" }, true, new string[] { "Left" }, new int[] { 1 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl017)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad" }, new string[] { "Well, I'm glad they agreed to a compromise. Let's just hope this has an effect. Do you want dinner, Heidi?", "I'm glad too. ...But I'm not hungry.", "...Oh, if you're sure, then. Good night, sweetie." }, true, new string[] { "Left", "Right", "Left" }, new int[] { 1, 4, 4 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl018)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad" }, new string[] { "Good morning, kiddo.", "Hi Dad!", "I have good news. The spread of the fish disease wasn't too bad today. Probably because they waited to put in fertilizer and didn't do it right before the rain.", "That's good!!! So is it fixed now?", "Not quite. There's still a lot of diseased fish in the water. But we're working on finding other ways to stop it.", "Okay. I'll go back to fishing now.", "Alright, bud. I'll tell you when we find a solution.",  "And I can help?", "Of course you can help. People are going hungry and we need all the help we get get. See you later, then." }, true, new string[] { "Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right", "Left" }, new int[] { 2, 1, 3, 2, 2, 3, 1, 1, 3 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl019)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "Come in, Heidi, let's eat dinner." }, true, new string[] { "Left" }, new int[] { 1 });
            }
        } else if (gameManager.currentState == GameManager.GameState.lvl022)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "I'm a bit busy. Go ahead n' keep fishing, bud." }, true, new string[] { "Left" }, new int[] { 1 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl023)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "Come in, Heidi." }, true, new string[] { "Left" }, new int[] { 4 });
            }
        }

        else if (gameManager.currentState == GameManager.GameState.lvl025)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad" }, new string[] { "Heidi. You need to know this.", "No one's been able to catch any fish so far today. It's getting really hard.", "Can I still try though?", "I mean... I'm not sure if it'll work...", "Dad, please. People depend on us for their food! I can't let them starve!", "...Well, alright, kiddo. Go ahead." }, true, new string[] { "Left", "Left", "Right", "Left", "Right", "Left" }, new int[] { 4, 7, 9, 5, 5, 6 });
            }
        }

        else if (gameManager.currentState == GameManager.GameState.lvl026)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad" }, new string[] { "Hey, kiddo. Come in." }, true, new string[] { "Left" }, new int[] { 5 });
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl028)
        {
            if (playerInBoundsToInteract && Input.GetKeyDown(KeyCode.E))
            {
                textTriggerScript.ScriptTriggered(new string[] { "Dad", "", "", "Heidi", "Dad", "", "Dad", "Dad", "Dad", "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad" }, new string[] { "Heidi! Did you notice?? The pollution- the fish-", "[Around you, the whole village was chattering excitedly.]", "[By the sound of it, the fish seemed to be coming back, too.]", "It's gone, Dad! I fixed it!", "You... fixed it?", "[You tell your dad everything about what happened.]", "Well... kiddo... wow.", "............", "I don't know what to say. I'm so proud of you.", "This could actually end up helping a lot of people, more than just the part of the city we're supposed to be taking care of. I'm going to call up newspapers and such to spread the word.", "Okay! I'm going to go keep fishing!", "Yeah, go ahead.", "...Psst. Heidi.", "Yeah?", "I'm proud of you. :)" }, true, new string[] { "Left", "None", "None", "Right", "Left", "None", "Left", "Left", "Left", "Left", "Right", "Left", "Left", "Right", "Left" }, new int[] { 1, 0, 0, 2, 2, 0, 3, 7, 1, 3, 3, 3, 1, 1, 2 });
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
