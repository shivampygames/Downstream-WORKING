using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RiverScript : IInteractable
    
{
    public Image water;
    private Coroutine fishingUiOpen;

    protected override void Start()
    {
        
        base.Start();
        water.enabled = false;


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
            interactText.text = "E to fish";
        }
        else
        {
            //onInteraction = false;
            interactText.text = "";
            if (fishingUiOpen != null)
            {
                water.enabled = false;
                StopCoroutine(fishingUiOpen);
                fishingUiOpen = null;
            }
        }


    }

    IEnumerator FishingUIOpenCoroutine()
    {

        water.enabled = true;
        interactText.text = "";

        // at this point you would start the other coroutine lol

        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        water.enabled = false;
        StopCoroutine(fishingUiOpen);
        fishingUiOpen = null;
        yield break;

    }

}
