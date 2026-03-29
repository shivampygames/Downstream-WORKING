using System.Globalization;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public enum GameState { backstory, lvl001 /* first dialogue */, lvl002andahalf /* the text telling what to do */, lvl002 /* first fishing wait until caught 10 fish*/, lvl003 /*interruption lol with the people*/, lvl004 /*have the converseation with people bro*/, lvl005 /*pop up with the daytime timer thing*/, lvl006 /*nighttime, go meet dad*/, lvl007 /* eat dinner with him */, lvl008 /* go sleep*/, lvl009, lvl010, lvl011, lvl012, lvl013, lvl014, lvl015, lvl016, lvl017, lvl018, lvl019, lvl020, lvl021, lvl022, lvl023, lvl024, lvl025, lvl026, lvl027, lvl028, lvl029 }

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


    // level 20

    bool setLevel20 = false;
    bool startedTalkingLevel20 = false;
    bool finishedTalkingLevel20 = false;

    //level 21

    bool setLevel21 = false;
    bool startedTalkingLevel21 = false;
    bool finishedTalkingLevel21 = false;

    //lvl 22
    bool setLevel22 = false;
    bool startedTalkingLevel22 = false;
    bool finishedTalkingLevel22 = false;

    //lvl 23
    bool setLevel23 = false;
    bool startedTalkingLevel23 = false;
    bool finishedTalkingLevel23 = false;

    //lvl 24

    bool setLevel24 = false;
    bool startedTalkingLevel24 = false;
    bool finishedTalkingLevel24 = false;

    // lvl 25
    bool setLevel25 = false;
    bool startedTalkingLevel25 = false;
    bool finishedTalkingLevel25 = false;


    // lvl 26
    bool setLevel26 = false;
    bool startedTalkingLevel26 = false;
    bool finishedTalkingLevel26 = false;


    // lvl 27
    bool setLevel27 = false;
    bool startedTalkingLevel27 = false;
    bool finishedTalkingLevel27 = false;
    bool startedStoryLevel27 = false;
    bool finishedStoryLevel27 = false;


    // lvl 28
    bool setLevel28 = false;
    bool startedTalkingLevel28 = false;
    bool finishedTalkingLevel28 = false;

    // lvl 29
    bool setLevel29 = false;
    bool pressedTheFinalOkButton = true; // temporarily


    // newspaper stuff
    public PlayerScript playerScript;
    public GameObject mainNewspaperGameObject;
    public UnityEngine.UI.Image newspaperImage;
    public GameObject fail;
    public GameObject pass;
    public GameObject nextButton;
    public GameObject retryButton;
    public Animator newspaperAnimate;
    public Animator timesUpAnimate;
    public GameObject timesUpFish;
    public Sprite[] newspaperSprites;


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
            case GameState.lvl020:
                lvl020();
                break;
            case GameState.lvl021:
                lvl021();
                break;
            case GameState.lvl022: 
                lvl022();
                break;
            case GameState.lvl023:
                lvl023();
                break;
            case GameState.lvl024:
                lvl024();
                break;
            case GameState.lvl025:
                lvl025();
                break;
            case GameState.lvl026:
                lvl026();
                break;
            case GameState.lvl027:
                lvl027();
                break;
            case GameState.lvl028:
                lvl028();
                break;
            case GameState.lvl029:
                lvl029();
                break;
            













        }
    }

    private void backstory()
    {
        if (backstoryScriptStarted == false)
        {
            textTriggerScript.ScriptTriggered(new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "" }, new string[] {"The world's farms have been plagued by a disease.", "It all started when the soil ran out of nutrients.", "People had been planting the same crops year after year. Those crops kept taking the same nutrients from the soil without putting anything in.", "After a while, there wasn't anything left in the ground for new plants to use.", "To fight this, new kinds of supercharged fertilizers and pesticides were invented. Everyone loved them and farms everywhere started using them.", "They claimed to make plants grow extra fast and healthy and strong. It was an attempt that came from good intentions.", "Instead, they turned everyone's crops mutated. Weird green growths appeared on the plants, and they turned sickly.", "Worse, it was contagious. The disease spread fast, leaving normal farms unusable and millions hungry. It turned into a widespread famine.", "People tried different tactics to fight the hunger. Some of them tried moving away from normal farms to grow their own plants.", "Some of them tried experimenting with different products to see which ones were the best- of course, none of them were completely clean, but some were less harmful than others.", "At some point, a group of starving people discovered a small patch in the forest.", "It was healthy and untouched by the disease. There wasn't enough space to farm there, but there was a river with fish in it. So the people decided to live there.", "For the past month, they had been catching fish and sending it back to the city in an attempt to feed people. Everything had been working great. So far." }, true, new string[] { "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic" }, new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1});
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
        
        objective.text = "You should probably get back to fishing soon. Try to catch as much as you can!";
        
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

            //newsaper stuff
            timesUpFish.SetActive(true);
            mainNewspaperGameObject.SetActive(true);
            timesUpAnimate.SetTrigger("TimesUp");
            playerScript.canProceedAfterNewspaper = false;
            if (riverScript.fishiesCaughtNumber >= 4)
            { 
                pass.SetActive(true);
                fail.SetActive(false);
                nextButton.SetActive(true);
                retryButton.SetActive(false);
                newspaperImage.sprite = newspaperSprites[0];
                newspaperAnimate.SetTrigger("NewspaperIn");
            } else
            {
                pass.SetActive(false);
                fail.SetActive(true);
                nextButton.SetActive(true);
                retryButton.SetActive(true);
                newspaperImage.sprite = newspaperSprites[0];
                newspaperAnimate.SetTrigger("NewspaperIn");
            }
            riverScript.CloseFishingWindowAndClearFish();
            mainNewspaperGameObject.SetActive(true);



            fire.SetActive(true);
            objective.text = "It's dinner time! Go talk to your dad.";
            volume.profile = normalNight1;
            timerBox.SetActive(false);
            timeUntilDay.SetActive(false);

            setLevel6 = true;

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

            timesUpFish.SetActive(false);
            mainNewspaperGameObject.SetActive(false);

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
                objective.text = "Go fish!!!!!";
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
            Debug.Log("is sequence dialogue null?" + textTriggerScript.sequenceDialogue == null);
            if (textTriggerScript.sequenceDialogue != null) { 
                startedTalkingLevel19 = true;

            }

        }

        if (startedTalkingLevel19 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel19 = true;
                currentState = GameState.lvl020;
            }
        }
    }

    private void lvl020()
    {
        if (setLevel20 == false)
        {
            tentBg.SetActive(true);
            textTriggerScript.ScriptTriggered(new string[] { "Heidi", "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad", "Dad", "Heidi", "Dad" }, new string[] {"Dad, the fish is getting worse.", "I know, Heidi. It IS getting worse.", "Did we find a solution?", "Well, we're going to try something.", "Tomorrow a bunch of us are going to plant shrubs and things on the edge of the river where the chemicals are getting in.", "How's that going to help?", "The plants' roots are going to form a kind of shield in the soil. They'll trap the excess fertilizer before it can get into the river.", "At least, that's the plan. We don't know how helpful it's going to be.", "Can I come with you?", "Yes, of course. Go to bed now, we're leaving early."}, true, new string[] { "Right", "Left", "Right", "Left", "Left", "Right", "Left", "Left", "Right", "Left" }, new int[] { 4, 2, 9, 7, 5, 1, 3, 7, 2, 1 });
            setLevel20 = true;
        }

        if (setLevel20 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel20 = true;
                currentState = GameState.lvl021;
            }
        }
    }

    private void lvl021()
    {
        if (setLevel21 == false)
        {
            tentBg.SetActive(false);
            volume.profile = redDay1;
            // at this point js get the text to do the whole story thing
            textTriggerScript.ScriptTriggered(new string[] {"", "", "", "", "", "", "", "", "" }, new string[] {"[The next morning.]", "[You walk with your dad and a few more people from your camp. You travel through the cold forest.]", "[It's hard not to notice the air being red with pollution.]", "[Or the plants on the ground being dead and diseased with the infection.]", "[Occasionally, you even spot a few wild animals, all of them similarly diseased. The forest looks bleak.]", "[Eventually, you make it to the edge of the river, just outside the farming settlement.]", "[You and your villagers spend the whole day hard at work planting shrubs on the edge of it.]", "[Eventually, the job gets done.]", "[And you leave to go back to camp.]" }, true, new string[] { "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic"}, new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1});

            setLevel21 = true;
        }

        if (setLevel21 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel21 = true;
                currentState = GameState.lvl022;
            }
        }
    }

    private void lvl022()
    {
        if (setLevel22== false)
        {
            objective.text = "You're home. Time to continue fishing.";
            riverScript.GameDifficultyFromZeroToSeven = 6;

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);

            setLevel22 = true;

        }

        if (CountDownTimer(2, 0, 0) == "over")
        {
            currentState = GameState.lvl023;
        }
    }

    private void lvl023()
    {
        if (setLevel23 == false)
        {
            
            volume.profile = normalNight1;
            objective.text = "Go eat dinner with your dad..";
            setLevel23 = true;
        }

        if (setLevel23 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel23 = true;
            }
        }

        if (startedTalkingLevel23 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel23 = true;
                currentState = GameState.lvl024;
            }
        }
    }

    private void lvl024()
    {
        if (setLevel24 == false)
        {
            tentBg.SetActive(true);
            textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Dad", "Dad", "Heidi", "Dad", "Heidi", "Heidi", "Dad", "Heidi" }, new string[] {"How was your day, Heidi?", "It's getting really hard to catch the fish. And I think the air is getting worse.", "...Yeah.", "........", "I'm going to be honest, Heidi. At the rate things are going, we might not be able to keep fishing.", "But people depend on us for food! We depend on OURSELVES for food!", "There's no food here anymore. We're better off finding someplace else.", "But...", "...........", "Heidi, listen. We'll think about it and then decide, okay? Let's just go to sleep for now.", "...Okay. Good night."}, true, new string[] { "Left", "Right", "Left", "Left", "Left", "Right", "Left", "Right", "Right", "Left", "Right" }, new int[] { 1, 7, 4, 7, 5, 6, 4, 9, 5, 7, 8 });
            setLevel24 = true;
        }

        if (setLevel24 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel24 = true;
                currentState = GameState.lvl025; 
            }
        }
    }

    private void lvl025()
    {
        if (setLevel25 == false)
        {
            tentBg.SetActive(false);
            volume.profile = redDay2;
            objective.text = "Say good morning to dad";
            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);
            riverScript.GameDifficultyFromZeroToSeven = 6;
            setLevel25 = true;
        }

        if (setLevel25 == true)
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel25 = true;
            }
        }

        if (startedTalkingLevel25 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel25 = true;
                objective.text = "Fish.";
            }
        }

        if (CountDownTimer(2, 0, 0) == "over")
        {
            currentState = GameState.lvl026;
        }

    }

    private void lvl026()
    {
        if (setLevel26 == false)
        {
            volume.profile = normalNight1;
            objective.text = "Go talk to dad.";
            setLevel26 = true;
        }
        
        if (setLevel26 == true )
        {
            if (textTriggerScript.sequenceDialogue != null)
            {
                startedTalkingLevel26 = true;

            }
        }

        if (startedTalkingLevel26 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel26 = true;
                currentState = GameState.lvl027;
            }
        }

    }

    private void lvl027()
    {
        if (setLevel27 == false)
        {
            tentBg.SetActive(true);
            textTriggerScript.ScriptTriggered(new string[] { "Dad", "Heidi", "Dad", "Heidi", "Dad", "Heidi", "Heidi", "Dad", "Heidi", "Dad" }, new string[] {"Heidi. It's getting worse. We should leave tomorrow. A few others are talking about leaving, too.", "But...! We're not going to try to save the fish? Or the forest animals?", "I don't think they can be saved. Not unless the farmers quit it with the pesticides and fertilizers.", "But they're never going to do that!", "That's right. The farmers have to feed themselves, too. It would have been nice if they could do it a little more sustainably, but...", "...............", "I want to go on a walk.", "It can't wait until the morning, bud?", "No. Can I go on a walk now? Please?", "...Alright... Be safe."}, true, new string[] { "Left", "Right", "Left", "Right", "Left", "Right", "Right", "Left", "Right", "Left" }, new int[] { 5, 6, 7, 9, 1, 6, 7, 5, 4, 7 });
            setLevel27 = true;
        }

        if (setLevel27 == true)
        {
            if (textTriggerScript.sequenceDialogue == null)
            {
                finishedTalkingLevel27 = true;
            }

            if (finishedTalkingLevel27 == true && startedStoryLevel27 == false) { 
                // at this point make the farming background show 
                textTriggerScript.ScriptTriggered(new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "" }, new string[] { "[You walk alongside the river through the trees of the forest. Everything is just as bleak as you remember.]", "[After a while of walking, you end up back at the spot where you and the others had grown the shrubs.]", "[Walking closer, you noticed something, though.]", "[There was a plant. One that was healthy and fresh. Uninfected.]", "[You saw it was growing from the fish scraps you'd left behind from your lunch.]", "[That was interesting. How was it growing without any fertilizer?]", "[Then you realized something. The fish WAS the fertilizer.]", "[That made sense, of course- the fish would have nutrients in it that the plants could use to grow.]", "[You looked up. The village of farmers was just across the river and you could easily show them. You eagerly ran to them.]", "Hey... you're that child from the fishers. What are you doing here, kid?", "I found a fertilizer!!! I found something you can use that's not chemicals!!!", "...What are you talking about?", "Look! It's in the forest! I'll show you!" }, true, new string[] { "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Left", "Right", "Left", "Right" }, new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 2, 0, 3});
                startedStoryLevel27 = true;
            }

            if (startedStoryLevel27 == true)
            {
                if (textTriggerScript.sequenceDialogue == null && finishedStoryLevel27 == false)
                {
                    // at this point i guess make the background the plant in the forest again
                    textTriggerScript.ScriptTriggered(new string[] { "Farmer", "Heidi", "Farmer", "Farmer", "Farmer", "Heidi", "Farmer", "Heidi", "Farmer", "Heidi", "Farmer", "Heidi", "" }, new string[] {"What... is this?", "Look! It's a healthy plant.", "Healthy?? No way, that's impossi-", "......................", "...How did you grow this?", "It grew from the fish!!", "This is... amazing. Fish scraps can be used as a fertilizer, then?", "Yes!!!! You can use them if you want!! I think it'll be useful for your plants!!", "...I don't suppose you're going to give us your fish so we can use it?", "I WILL give you my fish! But two conditions. You have to promise not to use any more chemicals. And allllll the extra food you need to give to hungry people back at the city.", ".........We'll test out your fish scraps fertilizer theory and then let you know.", "Okay!!!", "[They leave. Heidi goes home.]" }, true, new string[] { "Left", "Right", "Left", "Left", "Left", "Right", "Left", "Right", "Left", "Right", "Left", "Right", "None" }, new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                    finishedStoryLevel27 = true;
                }
            }

            if (finishedStoryLevel27 == true)
            {
                if (textTriggerScript.sequenceDialogue == null)
                {
                    // remove the previous backgrounds and stuff
                    currentState = GameState.lvl028;
                    fire.SetActive(false);
                }
            }

        }

    }

    private void lvl028()
    {
        if (setLevel28 == false)
        {
            tentBg.SetActive(false);
            volume.profile = normalDay1;
            objective.text = "You did it! Talk to your dad and then catch fish!";

            dayTimer = 0;
            ranThing = false;
            timerBox.SetActive(true);
            timeUntilDay.SetActive(true);

            setLevel28 = true;
        }

        if (CountDownTimer(2, 3, 0) == "over")
        {
            currentState = GameState.lvl029;
        }
    }

    private void lvl029()
    {
        if (pressedTheFinalOkButton == true) { 
            if (setLevel29 == false)
            {
                textTriggerScript.ScriptTriggered(new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" }, new string[] {"[Over the next few weeks, the fish scraps idea really did become popular.]", "[Many farms took up the fertilizer idea and many more people went out to go fishing. Farms began importing the natural fertilizer instead of chemicals with side effects.]", "[People learned other ways to stop runoff too- don't put fertilizer or pesticide on your crops right before it rains, and grow more plants along the edge of your fields to trap the runoff.]", "[They also figured out more things. For example, crop rotation. It's when you plant different kinds of crops each year.]", "[Crop rotation makes sure that one kind of plant doesn't just drain one kind of nutrient out of the soil. It makes the environment healthy and reduces need for fertilizer.]", "[In the end, the fish came back to life too, healthy and happy. And the forest animals that depended on the fish for food were also healthy and happy.]", "[In fact, the whole ecosystem was happy. And Heidi was happy too.]", "[When the food crisis finally calmed down, Heidi got to move back to the city where she hanged out with her friends and went to school. She got to play and learn instead of fishing and working.]", "[...Sadly, though, in the real world, the truth is that many people- including children- who suffer from food insecurity can't play or learn.]", "[They have to go work, either in the fields or just normal jobs, so that their family can have money for/or food.]", "[In fact, [statistic]", "[But one way to help start fighting that- and our environmental pollution problem- is by practicing sustainable farming.]", "[When you grow plants in your home or school or community garden, think about if you're being sustainable. What's in your fertilizers and pesticides? Is there a less harmful substitute you can use?]", "[And as a bonus, if you have extra food, you might even want to consider donating some to help people in need!]", "[Practicing sustainable farming is an easy way to help make our world better.]", "[That's the lesson Heidi learned. And so she lived happily ever after.]" }, true, new string[] { "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic", "Cinematic" }, new int[] { 1, 1, 1, 1, 1, 1, 1 , 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                setLevel29 = true;
            }

            if (setLevel29 == true)
            {
                if (textTriggerScript.sequenceDialogue == null)
                {
                    Debug.Log("GAME OVERRRRRRRRRRRRRR");
                }
            }
            
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

    public void NextButton()
    {
        newspaperAnimate.SetTrigger("NewspaperOut");
    }

    public void RetryButton()
    {
        newspaperAnimate.SetTrigger("NewspaperOut");
    }

}
