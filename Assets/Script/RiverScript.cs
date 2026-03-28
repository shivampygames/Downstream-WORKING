using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RiverScript : IInteractable

{
    public Image water;
    private Coroutine fishingUiOpen;
    public Image[] tiles;
    private Coroutine fish;
    public UnityEngine.UI.Button[] buttons;
    private int[] buttonsPressed = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public bool buttonPressed = false;
    public int whichButton;
    public GameObject allButtons;
    public Image orangeOutline;
    public Image fishPicture;
    public Animator fishAnimator;
    public Sprite[] fishies;
    public Sprite[] fishiesText;
    public Image fishTextSprite;
    public Animator fishTextAnimator;
    public int GameDifficultyFromZeroToSeven;
    private Coroutine fishTimer;
    public GameObject timerGameObject;
    public RawImage timerSquishDown;
    public Animator timerSquishAnimator;
    private int percentChanceOfDisease;
    public TMP_Text percentage;
    public GameManager gameManager;

    public int fishiesCaughtNumber;
    public TMP_Text fishiesCaught;

    // lvl starting varipable s i guess
    bool setLevel2 = false;


    protected override void Start()
    {

        base.Start();
        water.enabled = false;
        orangeOutline.enabled = false;
        timerGameObject.SetActive(false);
        if (fishTimer != null)
        {
            StopCoroutine(fishTimer);
            fishTimer = null;
        }

        //fishPicture.enabled = false;
        foreach (Image tile in tiles)
        {
            tile.enabled = false;

        }
        allButtons.SetActive(false);
        for (int i = 0; i < 16; i++)
        {
            buttonsPressed[i] = 0;
        }
        buttonPressed = false;
        orangeOutline.enabled = false;

        percentage.text = "0%";


    }
    protected override void Update()
    {

        if (gameManager.currentState == GameManager.GameState.backstory)
        {
            //runFishingScript(); 
        } else if (gameManager.currentState == GameManager.GameState.lvl001)
        {
            //runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl002andahalf)
        {
            //runFishingScript();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl002)
        {
            if (setLevel2 == false) {
                GameDifficultyFromZeroToSeven = 0;
                fishiesCaughtNumber = 00;
                fishiesCaught.text = "00";
                setLevel2 = true;
            }
            runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            // dont run the fishing script
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl005)
        {
            interactTextBox.SetActive(true);
        } else if (gameManager.currentState == GameManager.GameState.lvl006) 
        { 
        }
        else if (gameManager.currentState == GameManager.GameState.lvl007)
        {
            interactTextBox.SetActive(false);
        }
        else if (gameManager.currentState == GameManager.GameState.lvl008)
        {
            runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl009 || gameManager.currentState == GameManager.GameState.lvl010)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl011)
        {
            runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl012)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl013)
        {
            runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl014)
        {
            runFishingScript();
        } else if (gameManager.currentState == GameManager.GameState.lvl015)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl016)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl017)
        {
            interactTextBox.SetActive(false);
        } else if (gameManager.currentState == GameManager.GameState.lvl018)
        {
            runFishingScript();
        }

    }

    void runFishingScript()
    {
        base.Update();

        

        if (base.onInteraction)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //Debug.Log("lets go fishing!!");
                if (fishingUiOpen == null)
                {
                    fishingUiOpen = StartCoroutine(FishingUIOpenCoroutine());
                }
            }
        }

        if (playerInBounds && canInteract)
        {
            //onInteraction = true;
            if (fishingUiOpen == null)
            {
                base.interactTextBox.SetActive(true);
                interactText.text = "E to fish";
            }
            else
            {
                base.interactTextBox.SetActive(false);
                interactText.text = "";
            }
        }
        else
        {
            //onInteraction = false;
            base.interactTextBox.SetActive(false);
            interactText.text = "";
            if (fishingUiOpen != null)
            {
                water.enabled = false;
                orangeOutline.enabled = false;
                timerGameObject.SetActive(false);
                //fishPicture.enabled = false;
                if (fishingUiOpen != null)
                {
                    StopCoroutine(fishingUiOpen);
                }
                fishingUiOpen = null;
                if (fishTimer != null)
                {
                    StopCoroutine(fishTimer);
                    fishTimer = null;
                }



            }

            if (fish != null)
            {
                StopCoroutine(fish);
                fish = null;
                foreach (Image tile in tiles)
                {
                    tile.enabled = false;
                }
            }
        }

        Debug.Log(percentChanceOfDisease);
        percentage.text = percentChanceOfDisease + "%";

        fishiesCaught.text = fishiesCaughtNumber.ToString();
    }

    IEnumerator FishingUIOpenCoroutine()
    {
        orangeOutline.enabled = false;

        allButtons.SetActive(false);
        for (int i = 0; i < 16; i++)
        {
            buttonsPressed[i] = 0;
        }

        water.enabled = true;
        base.interactTextBox.SetActive(false);
        interactText.text = "";

        // at this point you would start the other coroutine lol
        if (fish == null)
        {
            fish = StartCoroutine(Fish());
        }

        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        water.enabled = false;
        orangeOutline.enabled = false;
        //fishPicture.enabled = false;
        timerGameObject.SetActive(false);
        if (fishingUiOpen != null) { 
        StopCoroutine(fishingUiOpen);
        }
        fishingUiOpen = null;
        if (fish != null)
        {
            StopCoroutine(fish);
            fish = null;
            foreach (Image tile in tiles)
            {
                tile.enabled = false;
            }
        }
        if (fishTimer != null)
        {
            StopCoroutine(fishTimer);
            fishTimer = null;
        }

        yield break;

    }

    IEnumerator Fish()
    {
        foreach (Image tile in tiles)
        {
            tile.enabled = true;
        }

        int numberOfBoops = UnityEngine.Random.Range(3, 6);
        int[] tilesNumber = new int[numberOfBoops];

        for (int i = 0; i < numberOfBoops; i++)
        {
            tilesNumber[i] = UnityEngine.Random.Range(0, 16);
        }

        yield return new WaitForSeconds(0.8f);

        for (int i = 0; i < numberOfBoops; i++)
        {
            Animator currentAnimatorTile = tiles[tilesNumber[i]].GetComponent<Animator>();
            currentAnimatorTile.SetTrigger("drop");
            yield return new WaitForSeconds(1.2f);

        }

        //here you would have the screen turn orange, indicating it's your turn
        orangeOutline.enabled = true;
        if (fishTimer == null)
        {
            fishTimer = StartCoroutine(FishTimerCoroutine(GameDifficultyFromZeroToSeven));
        } else if (fishTimer != null)
        {
            StopCoroutine(fishTimer);
            fishTimer = null;
            fishTimer = StartCoroutine(FishTimerCoroutine(GameDifficultyFromZeroToSeven));
        }


        for (int i = 0; i < 16; i++)
        {
            buttonsPressed[i] = 0;
        }

        buttonPressed = false;

        allButtons.SetActive(true);


        int[] buttonsPressedCoroutine = new int[numberOfBoops];
        for (int i = 0; i < numberOfBoops; i++)
        {
            yield return new WaitUntil(() => buttonPressed == true);
            //yield return new WaitForSeconds(0.001f);
            buttonPressed = false;
            buttonsPressedCoroutine[i] = whichButton;

        }

        bool userPressedCorrectly = true;

        for (int i = 0; i < numberOfBoops; i++)
        {
            //Debug.Log("Step " + i + ": Tile was " + tilesNumber[i] + ", you pressed " + buttonsPressedCoroutine[i]);


            if (buttonsPressedCoroutine[i] == tilesNumber[i])
            {
            }
            else
            {
                userPressedCorrectly = false;
            }
        }

        if (userPressedCorrectly)
        {
            int isTheFishNotDiseased = Random.Range(1, 101);
            if (isTheFishNotDiseased >= percentChanceOfDisease)
            {


                Debug.Log("+1 fish!");

                int hmmWhichFish = Random.Range(0, 5);
                fishPicture.sprite = fishies[hmmWhichFish];
                Debug.Log("trying to call " + fishies[hmmWhichFish].name);
                fishPicture.enabled = true;
                fishTextSprite.enabled = true;
                fishTextSprite.sprite = fishiesText[0];
                fishAnimator.SetTrigger("fishTrigger");
                fishTextAnimator.SetTrigger("fishTrigger");
                fishiesCaughtNumber++;

            } else
            {
                fishPicture.sprite = fishies[7];
                Debug.Log("womp womp heidi ur brains diseased");
                fishPicture.enabled = true;
                fishTextSprite.enabled = true;
                fishTextSprite.sprite = fishiesText[2];
                fishAnimator.SetTrigger("fishTrigger");
                fishTextAnimator.SetTrigger("fishTrigger");
            }

            
        }
        else
        {
            Debug.Log("The fish got away...");
            fishTextSprite.enabled = true;
            fishPicture.sprite = fishies[6];
            fishTextSprite.sprite = fishiesText[1];
            fishAnimator.SetTrigger("fishTrigger");
            fishTextAnimator.SetTrigger("fishTrigger");
        }

        allButtons.SetActive(false);

        water.enabled = false;
        orangeOutline.enabled = false;
        timerGameObject.SetActive(false);
        //fishPicture.enabled = false;
        if (fishingUiOpen != null) { 
        StopCoroutine(fishingUiOpen);
        }
        fishingUiOpen = null;
        if (fishTimer != null)
        {
            StopCoroutine(fishTimer);
            fishTimer = null;
        }
        
        foreach (Image tile in tiles)
        {
            tile.enabled = false;
        }

        if (fish != null)
        {
            StopCoroutine(fish);
        }
        fish = null;
        yield break;

    }

    public void buttonPress(int whichButtonWasIt)
    {
        whichButton = whichButtonWasIt - 1;
        buttonPressed = true;

    }
        
    IEnumerator FishTimerCoroutine(int gameDifficulty)
    {
        
        timerSquishAnimator.SetInteger("level", 0);
        percentChanceOfDisease = 0;
        timerGameObject.SetActive(false);

        if (gameDifficulty == 0)
        {
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;
        }
        else if (gameDifficulty == 1)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 30; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 30;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
        else if (gameDifficulty == 2)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 20; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 20;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
        else if (gameDifficulty == 3)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 15; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 15;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
        else if (gameDifficulty == 4)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 10; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 10;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
        else if (gameDifficulty == 5)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 6; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 6;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null)
            {
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
        else if (gameDifficulty == 6)
        {
            timerGameObject.SetActive(true);
            timerSquishAnimator.SetInteger("level", gameDifficulty);
            for (int i = 0; i < 3; i++)
            {
                percentChanceOfDisease = percentChanceOfDisease + 80 / 3;
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitUntil(() => fishingUiOpen == null);
            timerSquishAnimator.SetInteger("level", 0);
            timerGameObject.SetActive(false);
            if (fishTimer != null) { 
                StopCoroutine(fishTimer);
            }
            fishTimer = null;
            yield break;

        }
    }

}

