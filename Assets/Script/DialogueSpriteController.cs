using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueSpriteController : MonoBehaviour
{

    public Image leftSprite;
    public Image rightSprite;
    public List<Sprite> leftSprites = new List<Sprite>();
    public List<Sprite> rightSprites = new List<Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSprite.sprite = leftSprites[0];
        ;
        rightSprite.sprite = rightSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLeftSprite(int spriteIndex)
    {
        rightSprite.sprite = rightSprites[0];
        leftSprite.sprite = leftSprites[spriteIndex];
    }

    public void changeRightSprite(int spriteIndex)
    {
        rightSprite.sprite = rightSprites[spriteIndex];
        leftSprite.sprite = leftSprites[0];
    }

    public void clearSprites()
    {
        rightSprite.sprite = rightSprites[0];
        leftSprite.sprite= leftSprites[0];
    }

}
