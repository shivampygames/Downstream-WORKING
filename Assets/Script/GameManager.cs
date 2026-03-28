using System.Globalization;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{

    public enum GameState { backstory, lvl001 /* first dialogue */, lvl002andahalf /* the text telling what to do */, lvl002 /* first fishing wait until caught 10 fish*/, lvl003 /*interruption lol with the people*/, lvl004 /*have the converseation with people bro*/, lvl005 /*pop up with the daytime timer thing*/, lvl006 /*nighttime, go meet dad*/, lvl007 /* eat dinner with him */, lvl008 /* go sleep*/, lvl009, lvl010, lvl011, lvl012, lvl013, lvl014, lvl015, lvl016, lvl017, lvl018, lvl019 }

    public GameState currentState;

    public bool readyForLevel2 = false;

    public DialogueTextTriggerScript textTriggerScript;

    private bool backstoryScriptStarted = false;

    private bool setUpLevel1 = false;

    public RiverScript riverScript;

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
    public VolumeProfile redDay1;
    public VolumeProfile redSkiesEvening;
    public VolumeProfile redDay2;

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

    public GameObject tentBg;

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

    // level 8
    bool setLevel8 = false;
    bool startedTalkingLevel8 = false;
    bool finishedTalkingLevel8 = false;

    //level 9
    bool setLevel9 = false;
    bool startedTalkingLevel9 = false;
    bool finishedTalkingLevel9 = false;

    //level 10
    bool setLevel10 = false;
    bool finishedTalkingLevel10 = false;

    //level 11
    bool setLevel11 = false;
    bool startedTalkingLevel11 = false;
    bool finishedTalkingLevel11 = false;

    // level 12
    bool setLevel12 = false;
    bool startedTalkingLevel12 = false;
    bool finishedTalkingLevel12 = false;

    // level 13
    bool setLevel13 = false;
    bool startedTalkingLevel13 = false;
    bool finishedTalkingLevel13 = false;

    //lvl 14
    bool setLevel14 = false;
    bool startedTalkingLevel14 = false;
    bool finishedTalkingLevel14 = false;

    //level  15
    bool setLevel15 = false;
    bool startedTalkingLevel15 = false;
    bool finishedTalkingLevel15 = false;

    //levle 16
    bool setLevel16 = false;
    bool startedTalkingLevel16 = false;
    bool finishedTalkingLevel16 = false;

    //lrbrl 17
    bool setLevel17 = false;
    bool startedTalkingLevel17 = false;
    bool finishedTalkingLevel17 = false;

    //level 18

    bool setLevel18 = false;
    bool startedTalkingLevel18 = false;
    bool finishedTalkingLevel18 = false;

    //level 19

    bool setLevel19 = false;
    bool startedTalkingLevel19 = false;
    bool finishedTalkingLevel19 = false;

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
            case GameState.lvl008:
                lvl008();
                break;
            case GameState.lvl009:
                lvl009();
                break;
            case GameState.lvl010:
                lvl010();
                break;
            case GameState.lvl011:
                lvl011();
                break;
            case GameState.lvl012:
                lvl012();
                break;
            case GameState.lvl013:
                lvl013();
                break;
            case GameState.lvl014:
                lvl014();
                break;
            case GameState.lvl015:
                lvl015();
                break;
            case GameState.lvl016:
                lvl016();
                break;
            case GameState.lvl017:
                lvl017();
                break;
            case GameState.lvl018:
                lvl018();
                break;
            case GameState.lvl019:
                lvl019();
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
            textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Heidi", "Heidi", "Dad", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad" }, new string[] { "Here's your food, bud.", "Thanks.", "So how was your day today? You do anything interesting?", "Spent the whole day working. Catching fish.", "...The usual.", "................", "...I see.", "Look, Heidi. I'm sorry this happened to us. I wish we could go back to the city too.", "I know. Ya told me before.", "I know I've told you before. I'm still sorry.", "It's okay.", "...Did you hear the news? One of our fish came out sick today. They're saying it looked like the same disease that happened to our crops.", "Ya, I was there.", "And what did you think?", "It sure looked like the same disease, I guess. I'm done eating now.", "Alright, sweetie. Y'know, I still have one of your favorite board games you used to love. We could play that before bed if you want.", "Don't we need to go to sleep early? So that we can go back to fishing tomorrow?", "...Are you sleepy?", "Yes.", "Ah. Okay, good night, kiddo. Love you." }, true, new string[] { "Left", "Right", "Left", "Right", "Right", "Left", "Left", "Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right", "Left" }, new int[] { 3, 3, 1, 4, 7, 4, 6, 7, 4, 5, 9, 5, 7, 6, 4, 3, 7, 5, 8, 7 });
            tentBg.SetActive(true);
            setLevel7 = true;
        }

        if (setLevel7 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                currentState = GameState.lvl008;
            }
        }

    }

    private void lvl008()
    {
        Debug.Log("ay wsp twin");
        

        if (setLevel8 == false)
        {

            riverScript.GameDifficultyFromZeroToSeven = 2;
            volume.profile = normalDay1;
            tentBg.SetActive(false);
            objective.text = "Go say good morning to your dad.";

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);
            
            

            setLevel8 = true;
        }

        if (setLevel8 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel8 = true;
            }

            if (startedTalkingLevel8 == true)
            {
                if (textTriggerScript.sequenceDialogue == null)
                {
                    finishedTalkingLevel8 = true;
                }
            }
        }


        if (finishedTalkingLevel8 == true)
        {
            objective.text = "Try to catch as much fish as you can.";
        }



        if (CountDownTimer(1, 3, 0) == "over")
        {
            currentState = GameState.lvl009;
        }

    }

    private void lvl009()
    {
        if (setLevel9 == false)
        {
            volume.profile = normalNight1;
            objective.text = "Go visit dad.";
            textTriggerScript.StopAllDialogue();

            
            
            setLevel9 = true;
        }

        if (setLevel9 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel9 = true;
            }
        }
        if (startedTalkingLevel9 == true) { 
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel9 = true;
                currentState = GameState.lvl010;
            }
        }

    }

    private void lvl010()
    {
        if (setLevel10 == false)
        {
            textTriggerScript.ScriptTriggered(new string[] {"Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi" }, new string[] {"Hey, kiddo. How was your day?", "It was okay. I caught a lot of fish, I think.", "That's good. We got the newspaper today. Apparently, the farm up the river has been testing a new kind of chemical fertilizer on their plants. We think it's running into our water and hurting the fish.", "Are we going to do anything to stop it?", "We're sending a few of our people out to talk to them tomorrow.", "That's good.", "........Heidi, just remember, the fish disease might not get better soon. We should try to stock up on fish, it would be good to have it in storage just in case anything bad happens.", "Okay. I'm going to sleep now, Dad. Good night." }, true, new string[] {"Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right"}, new int[] { 2, 3, 5, 9, 3, 4, 7, 1});
            tentBg.SetActive(true);
            setLevel10 = true;
        }

        if (setLevel10 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel10 = true;
            }
        }

        if (finishedTalkingLevel10 == true) { 
            if (setLevel10 == true)
            {
                tentBg.SetActive(false);
                currentState = GameState.lvl011;
            }
        }

    }

    private void lvl011()
    {
        if (setLevel11 == false)
        {
            volume.profile = normalDay1;
            riverScript.GameDifficultyFromZeroToSeven = 3;
            objective.text = "Go say good morning to your dad.";

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);

            setLevel11 = true;
        }

        if (setLevel11 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel11 = true;
            }
        }

        if (startedTalkingLevel11)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel11 = true;
            }
        }

        if (finishedTalkingLevel11)
        {
            objective.text = "Try to catch some fish...?";
        }

        if (CountDownTimer(1, 3, 0) == "over")
        {
            currentState = GameState.lvl012;
        }

    }

    private void lvl012()
    {
        if (setLevel12 == false)
        {
            volume.profile = normalNight1;
            objective.text = "It's time to eat dinner. Go visit dad.";
            textTriggerScript.StopAllDialogue();
            setLevel12 = true;
        }

        if (setLevel12 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel12 = true;
            }
        }

        if (startedTalkingLevel12 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel12 = true;
                currentState = GameState.lvl013;
            }
        }
    }

    private void lvl013()
    {
        if (setLevel13 == false)
        {
            tentBg.SetActive(true);
            textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Dad" }, new string[] { "Here, have some fish. We might have to start rationing soon. Don't wanna eat all the fish and leave nothing for all those poor souls we're supposed to be feeding.", "Did we talk to the farming village up there?", "Yup, visited them yesterday.", "...It's like we suspected. The chemicals they're testing- fertilizer, pesticides- seem to be getting into our water. They're not dumping it on purpose, but there's still runoff.", "WHY are they still testing chemicals. We already know those are bad?", "Chemicals are harmful. But those people are probably hungry.", "We can't ask them to stop using their bad fertilizer?", "We can't ask them to starve, can we?", "The famine is getting worse, so they're just going to have to keep using fertilizers. And our fish is getting worse by the day too.", "What are we going to do if there's no more good fish left here?", "I'm sure there'll be some other work we can do. Maybe go back to the city.", "But there's no food there.", "...We'll figure it out, kiddo. Go to your tent, now. Hurry, before it starts raining.", "Raining?", "Yes, it's scheduled to rain tonight. Go now. Good night, kiddo." }, true, new string[] { "Left", "Right", "Left", "Left", "Right", "Left", "Right", "Left", "Left", "Right", "Left", "Right", "Left", "Right", "Left" }, new int[] { 7, 8, 5, 6, 6, 1,9, 3, 4, 4, 3, 5, 2, 4, 3 });

            //textTriggerScript.ScriptTriggered(new string[] { "Dad", "" }, new string[] {"Hey, Heidi. Good morning.." }, true, new string[] { }, new int[] { });
            setLevel13 = true;

        }

        if (setLevel13 == true) { 
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel13 = true;

            }
        }


        if (startedTalkingLevel13 == true)
        {
            {
                if (textTriggerScript.sequenceDialogue == null)
                {
                    finishedTalkingLevel13 = true;
                    currentState = GameState.lvl014;
                }
            }
        }
    }

    private void lvl014()
    {
        if (setLevel14 == false)
        {
            tentBg.SetActive(false);
            Debug.Log("we DID it baby we're good now, level 14 lets go");
            volume.profile = redDay1;
            riverScript.GameDifficultyFromZeroToSeven = 4;
            objective.text = "Go talk to dad...?";

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);

            setLevel14 = true;
        }
        if (setLevel14 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel14 = true;
            }
        }
        if (startedTalkingLevel14 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel14 = true;
            }
        }

        if (CountDownTimer(2, 0, 0) == "over")
        {
            currentState = GameState.lvl015;
        }

    }

    private void lvl015()
    {
        if (setLevel15 == false)
        {
            textTriggerScript.StopAllDialogue();
            volume.profile = redSkiesEvening;
            objective.text = "We're visiting the farmers upstream! Go talk to dad!";
            setLevel15 = true;
        }

        if (setLevel15 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel15 = true;
            }
        }

        if (startedTalkingLevel15)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel15 = true;
            }
        }

        if (finishedTalkingLevel15 == true)
        {
            currentState = GameState.lvl016;
        }

    }

    private void lvl016()
    {
        if (setLevel16 == false)
        {
            tentBg.SetActive(true);
            textTriggerScript.ScriptTriggered(new string[] { "", "Dev", "Farmer", "Dev", "Farmer", "Dev", "Farmer", "Farmer", "Dev" }, new string[] {"[After a short while of hiking up the mountain, you arrive at the farming village. One of your group's members steps up to talk to one of theirs.]", "Good evening.", "You're back again? What is it this time? We're not getting rid of our fertilizer. Our people are going hungry-", "Woah. Okay. But could we make a request?", "...What?", "Can you not use chemicals right before it rains? The rain is making it wash off into our river more.", "................", "Fine. But that's the only compromise we're doing.", "Thank you so much. Come on, guys, let's go." }, true, new string[] { "None", "Left", "Left", "Left", "Left", "Left", "Left", "Left", "Left" }, new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0 });
            setLevel16 = true;
        }

        if (setLevel16 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel16 = true;
            }
        }

        if (startedTalkingLevel16 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel16 = true;
                currentState = GameState.lvl017;
            }
        }
        if (finishedTalkingLevel16 == true)
        {
            currentState = GameState.lvl017;
        }

    }

    private void lvl017()
    {
        if (setLevel17 == false)
        {
            tentBg.SetActive(false);
            volume.profile = normalNight1;
            objective.text = "Tell your dad good night before you go to sleep.";
            setLevel17 = true;
        }

        if (setLevel17 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel17 = true;
            }
        }

        if (startedTalkingLevel17 == true )
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel17 = true;
                currentState = GameState.lvl018;
            }
        }

    }

    private void lvl018()
    {
        if (setLevel18 == false)
        {
            riverScript.GameDifficultyFromZeroToSeven = 5;
            volume.profile = redDay1;
            objective.text = "Tell your dad good morning.";

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);

            setLevel18 = true;
        }

        if (setLevel18 == true)
        {
            if (textTriggerScript.sequenceDialogue != null) { 
                startedTalkingLevel18 = true;
            }
        }

        if (startedTalkingLevel18) { 
            if (textTriggerScript.sequenceDialogue == null) { 
                finishedTalkingLevel18 = true;
                objective.text = "Try to catch some more fish.";
            }
        }


        if (CountDownTimer(2, 0, 0) == "over")
        {
            textTriggerScript.StopAllDialogue();
            currentState = GameState.lvl019;
        }


    }

    private void lvl019()
    {
        if (setLevel19 == false) 
        {
            volume.profile = normalNight1;
            objective.text = "Go eat dinner with your dad.";

            setLevel19 = true;
        } 

        if (setLevel19 == true)
        {
            Debug.Log("level 19 lets gooooo");
            
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
