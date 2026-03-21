using System.Collections;
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

    protected override void Start()
    {

        base.Start();
        water.enabled = false;
        orangeOutline.enabled = false;
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


    }
    protected override void Update()
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
                interactText.text = "E to fish";
            }
            else
            {
                interactText.text = "";
            }
        }
        else
        {
            //onInteraction = false;
            interactText.text = "";
            if (fishingUiOpen != null)
            {
                water.enabled = false;
                orangeOutline.enabled = false;
                //fishPicture.enabled = false;
                StopCoroutine(fishingUiOpen);
                fishingUiOpen = null;



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
        StopCoroutine(fishingUiOpen);
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

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < numberOfBoops; i++)
        {
            Animator currentAnimatorTile = tiles[tilesNumber[i]].GetComponent<Animator>();
            currentAnimatorTile.SetTrigger("drop");
            yield return new WaitForSeconds(1.2f);

        }

        //here you would have the screen turn orange, indicating it's your turn
        orangeOutline.enabled = true;


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
            Debug.Log("+1 fish!");
            
            int hmmWhichFish = Random.Range(0, 5);
            fishPicture.sprite = fishies[hmmWhichFish];
            Debug.Log("trying to call " + fishies[hmmWhichFish].name);
            fishPicture.enabled = true;
            fishTextSprite.enabled = true;
            fishTextSprite.sprite = fishiesText[0];
            fishAnimator.SetTrigger("fishTrigger");
            fishTextAnimator.SetTrigger("fishTrigger");

            
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
        //fishPicture.enabled = false;
        StopCoroutine(fishingUiOpen);
        fishingUiOpen = null;
        
        foreach (Image tile in tiles)
        {
            tile.enabled = false;
        }

        StopCoroutine(fish);
        fish = null;
        yield break;

    }

    public void buttonPress(int whichButtonWasIt)
    {
        whichButton = whichButtonWasIt - 1;
        buttonPressed = true;

    }

}

