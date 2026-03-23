using System.Globalization;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState { backstory, lvl001 /* first dialogue */, lvl002 /* first fishing wait until caught 10 fish*/, lvl003 /*interruption lol with the people*/, lvl004 /*pop up with the daytime timer thing*/, lvl005 /*go back to fishing with the newly added daytime timer*/, lvl006 /*go talk to dad (AT THIS POINT HE EATS THE FISH)*/, lvl007 /*eachnightlasts1minutetextboxpopup*/, lvl008 /*monstergamething*/, lvl009 /*go talk to dad*/, lvl010 /*go sleep*/ }

    public GameState currentState;

    public bool readyForLevel2 = false;

    public DialogueTextTriggerScript textTriggerScript;

    private bool backstoryScriptStarted = false;

    private bool setUpLevel1 = false;

    public GameObject UI;
    public TMP_Text objective;
    
    public TMP_Text fishCount;

    public GameObject theArrow;

    // things the arrow needs to look at: 
    public GameObject dadPosition;
    public GameObject riverPosition;


    //level 1 variables
    bool calledTheUI = false;
    public bool riverSequenceStarted = false;
    public bool startedTalkingToDad = false;
    bool reachedTheRiver = false;
    

    //public GameObject villageHunger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.backstory;
        UI.SetActive(false);
        theArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.backstory:
                backstory();
                break;
            case GameState.lvl001:
                lvl001();
                break;
            case GameState.lvl002:
                lvl002();
                break;
        }
    }

    private void backstory()
    {
        if (backstoryScriptStarted == false)
        {
            textTriggerScript.ScriptTriggered(new string[] { "", "", "", "", "", "", "", "" }, new string[] { "Once upon a time, there was a quiet, snowy forest. Peaceful and undisturbed in a valley between white-frosted mountains.", "Deep inside, a village was nestled between the evergreens. It was cozy and small and the people lived in cabins and tents.", "They called it Fisherville because of the flowing river that gave it life.", "Every day, the river gave its people beautiful healthy fish, in every color of the rainbow. Their food gave them energy to spend their days drawing, swimming, running and playing in the trees.", "Then at night, when the lights went down and all the forest animals came out, it was just as peaceful as the daytime.", "The village people would eat their fish by their fire in quiet contentment.", "They were happy in the knowledge that they were safe, and there was more than enough fish to keep all their bellies full.", "And in the morning, when the sun rose, the people of Fisherville would get up to visit their river. Preparing their food for the day." }, true, new string[] { "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic" }, new int[] { 0, 0, 2, 3, 4, 5, 6, 7 });
            backstoryScriptStarted = true;
        }
        if (textTriggerScript.sequenceDialogue == null)
        {
            currentState =  GameState.lvl001;
        }

    }
    private void lvl001()
    {
        
        Debug.Log("omg level 1 ltes go");
        
        

        if (setUpLevel1 == false)
        {
            textTriggerScript.ScriptTriggered(new string[] { "", "Dad" }, new string[] { "[You wake up in your tent.]", "Heidi!!! It's time to wake up!" }, true, new string[] { "None", "Left" }, new int[] { 0, 1 });
            setUpLevel1 = true;
        }

        if ((textTriggerScript.sequenceDialogue == null) && (calledTheUI == false))
        {
            UI.SetActive(true);
            objective.text = "Talk to Dad (Right-click and drag on your mouse to look around. WASD while holding right-click to move)";
            theArrow.SetActive(true);
            calledTheUI = true;
        }

        if ((calledTheUI == true) && (riverSequenceStarted == false))
        {
            ArrowPoint(dadPosition);
        }
        
        if ((calledTheUI == true) && (startedTalkingToDad == false)) 
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingToDad = true;
            }
        }

        
        if ((startedTalkingToDad == true) && (riverSequenceStarted == false))
        {
            theArrow.SetActive(false);

            if (textTriggerScript.sequenceDialogue == null)
            {
                riverSequenceStarted = true;
            }
        }

        if ((riverSequenceStarted == true) && (reachedTheRiver == false))
        {
            theArrow.SetActive(true);
            objective.text = "Head to the river to catch fish.";
            ArrowPoint(riverPosition);
            float distanceBetweenCharAndRiver;
            Vector3 diff = (theArrow.transform.position - riverPosition.transform.position);
            diff.y = 0;
            distanceBetweenCharAndRiver = diff.magnitude;
            if ((distanceBetweenCharAndRiver < 6.7) && (reachedTheRiver == false))
            {
                reachedTheRiver = true;
                readyForLevel2 = true;
            }
        }


        if (readyForLevel2 == true)
        {
            currentState = GameState.lvl002;

        }

    }

    private void lvl002()
    {
        Debug.Log("ong we r in lvl 2 lol");
    }

    private void ArrowPoint(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = theArrow.transform.position.y;
        //theArrow.transform.LookAt(targetPosition);

        Vector3 direction = targetPosition - theArrow.transform.position;

        if (direction.magnitude > 0.1f)
        {
            theArrow.transform.rotation = Quaternion.LookRotation(direction);
        }
    }

}
