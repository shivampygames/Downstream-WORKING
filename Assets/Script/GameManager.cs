using System.Globalization;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{

    public enum GameState { backstory, lvl001 /* first dialogue */, lvl002andahalf /* the text telling what to do */, lvl002 /* first fishing wait until caught 10 fish*/, lvl003 /*interruption lol with the people*/, lvl004 /*have the converseation with people bro*/, lvl005 /*pop up with the daytime timer thing*/, lvl006 /*nighttime, go meet dad*/, lvl007 /* eat dinner with him */, lvl008 /* go sleep*/ }

    public GameState currentState;

    public bool readyForLevel2 = false;

    public DialogueTextTriggerScript textTriggerScript;

    private bool backstoryScriptStarted = false;

    private bool setUpLevel1 = false;

    public GameObject UI;
    public TMP_Text objective;

    public TMP_Text fishCount;

    public GameObject theArrow;

    public GameObject fishingInstructionsIdk;

    public float dayTimer = 0f;

    public GameObject timerBox;
    public GameObject timeUntilDay;

    public GameObject fire;


    // post provessing stuff
    public Volume volume;
    public VolumeProfile normalDay1;
    public VolumeProfile normalNight1;

    // time counters fr
    int timer4thdigit = 0;
    int timer3rddigit = 0;
    int timer2nddigit = 0;
    int timer1stdigit = 0;
    public TMP_Text fourthDigit;
    public TMP_Text thirdDigit;
    public TMP_Text secondDigit;
    public TMP_Text firstDigit; 
    bool ranThing = false;

    // things the arrow needs to look at: 
    public GameObject dadPosition;
    public GameObject riverPosition;
    public GameObject theCommotionLocation;

    //public TMP_Text fishCountingText;

    //level 1 variables
    bool calledTheUI = false;
    public bool riverSequenceStarted = false;
    public bool startedTalkingToDad = false;
    bool reachedTheRiver = false;

    //level 2 and  ahalf veriables
    bool startedFishingTutorial = false;

    // level 2 variables
    bool setLevelTwo = false;

    //public GameObject villageHunger;

    //level 3 variables
    bool setLevelThree = false;

    // level 4 variables

    bool startedTalking = false;

    // level 5 variables
    bool setLevel5 = false;

    // level 6 variables
    bool setLevel6 = false;

    //level 7 variables
    bool setLevel7 = false;
    bool startedTalkingToDad7 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.backstory;
        UI.SetActive(false);
        theArrow.SetActive(false);
        fishingInstructionsIdk.SetActive(false);
        timerBox.SetActive(false);
        timeUntilDay.SetActive(false);
        fire.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GameState.backstory:
                backstory();
                break;
            case GameState.lvl002andahalf:
                lvl002andahalf();
                break;
            case GameState.lvl001:
                lvl001();
                break;
            case GameState.lvl002:
                lvl002();
                break;
            case GameState.lvl003:
                lvl003();
                break;
            case GameState.lvl004:
                lvl004();
                break;
            case GameState.lvl005:
                lvl005();
                break;
            case GameState.lvl006:
                lvl006();
                break;
            case GameState.lvl007:
                lvl007(); 
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
            currentState = GameState.lvl001;
        }

    }
    private void lvl001()
    {

        Debug.Log("omg level 1 ltes go");



        if (setUpLevel1 == false)
        {
            textTriggerScript.ScriptTriggered(new string[] { "", "Dad" }, new string[] { "[You wake up in your tent.]", "Heidi!!! It's time to wake up!" }, true, new string[] { "None", "Left" }, new int[] { 0, 1 });
            volume.profile = normalDay1;
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
            if ((distanceBetweenCharAndRiver < 4) && (reachedTheRiver == false))
            {
                reachedTheRiver = true;
                readyForLevel2 = true;
            }
        }


        if (readyForLevel2 == true)
        {
            currentState = GameState.lvl002andahalf;

        }

    }

    private void lvl002andahalf()
    {
        if (startedFishingTutorial == false)
        {
            fishingInstructionsIdk.SetActive(true);
        }
    }

    private void lvl002()
    {
        Debug.Log("ong we r in lvl 2 lol");
        if (setLevelTwo == false) { 
            theArrow.SetActive(false);
            fishingInstructionsIdk.SetActive(false);
            setLevelTwo = true;
            objective.text = "Try catching a couple of fish";
        }

        if (fishCount.text == "4")
        {
            currentState = GameState.lvl003;
        }


    }

    private void lvl003()
    {
        Debug.Log("l-l-l-level 3? *makes puppy eyes uwu so kawaii (someone beat me up bro)");
        if (setLevelThree == false)
        {
            textTriggerScript.ScriptTriggered(new string[] { "", "Person", "" }, new string[] { "[You suddenly hear another fisher call out in surprise.]", "AHHH!!! THE FISH!", "[You notice everyone gathers around them in concern.]" }, true, new string[] { "None", "Left", "None" }, new int[] { 0, 0, 0 }); // change the second zero to the actual sprite when you draw it
            setLevelThree = true;
        }

        if (textTriggerScript.sequenceDialogue == null)
        {
            objective.text = "Go see what the commotion is.";
            theArrow.SetActive(true);
            ArrowPoint(theCommotionLocation);
            float distanceToCommotion = Mathf.Abs(((theArrow.transform.position - theCommotionLocation.transform.position)).magnitude);
            if (distanceToCommotion < 2.67f) 
            {
                currentState = GameState.lvl004;
            }
        }

    }

    private void lvl004()
    {
        theArrow.SetActive(false);

        if (textTriggerScript.sequenceDialogue != null)
        {
            startedTalking = true;
        }
        
        if (startedTalking == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                currentState = GameState.lvl005;
            }
        }
    }

    private void lvl005()
    {
        
        objective.text = "You should probably get back to fishing soon.";
        
        if (setLevel5 == false)
        {
            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);
            setLevel5 = true;
        }

        if (CountDownTimer(0, 3, 0) == "over")
        {
            currentState = GameState.lvl006;
        }
        

    }

    private void lvl006()
    {
        if (setLevel6 == false)
        {
            fire.SetActive(true);
            objective.text = "It's dinner time! Go talk to your dad.";
            volume.profile = normalNight1;
            timerBox.SetActive(false);
            timeUntilDay.SetActive(false);
        }
        Debug.Log("six sevennnnn");

        if (textTriggerScript.sequenceDialogue != null)
        {
            startedTalkingToDad7 = true;
        }

        if (startedTalkingToDad7 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                currentState = GameState.lvl007;
            }
        }
    }

    private void lvl007()
    {
        Debug.Log("part two of level 67");
        if (setLevel7 == false)
        {

        }
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

    public void goToLevelTwo()
    {
        currentState = GameState.lvl002;
    }

    public string CountDownTimer(int howManyMinutes, int howManySecondsFirstPlace, int howManySecondsSecondPlace)
    {
        float lvl5daytimer;
        float timeRemaining;
        if (ranThing == false)
        {
            timeRemaining = howManySecondsSecondPlace + (howManySecondsFirstPlace*10) + (howManyMinutes*60);
            if (howManyMinutes != 0)
            {
                timer2nddigit = howManyMinutes;
                timer3rddigit = howManySecondsFirstPlace;
                timer4thdigit = howManySecondsSecondPlace;
            }
            ranThing = true;
        }


        dayTimer += Time.deltaTime;
        lvl5daytimer = Mathf.Round(dayTimer);
        Debug.Log(lvl5daytimer);

        int timeRemainingInt = (int)(howManySecondsSecondPlace + (howManySecondsFirstPlace * 10) + (howManyMinutes * 60) - lvl5daytimer); 

        int convertToNearestMinute = (int)(timeRemainingInt / 60);
        timer2nddigit = convertToNearestMinute;
        int remainingSeconds = (int)(timeRemainingInt - (convertToNearestMinute*60));
        string timerSeconds = remainingSeconds.ToString();
        if (timerSeconds.Length == 1)
        {
            timer3rddigit = 0;
            //timer4thdigit = int.Parse(remainingSeconds.ToString()[0]);
            timer4thdigit = remainingSeconds;
        } else {
            //timer3rddigit = remainingSeconds.ToString()[0];
            //timer4thdigit = remainingSeconds.ToString()[1];
            timer3rddigit = remainingSeconds / 10;
            timer4thdigit = remainingSeconds % 10;
        }

        firstDigit.text = "0";
        secondDigit.text = timer2nddigit.ToString();
        thirdDigit.text = timer3rddigit.ToString();
        fourthDigit.text = timer4thdigit.ToString();



        if (lvl5daytimer >= howManySecondsSecondPlace + (howManySecondsFirstPlace * 10) + (howManyMinutes * 60))
        {
            lvl5daytimer = 0;
            return "over";
        }
        else
        {
            return "still going";
        }

    }

}
