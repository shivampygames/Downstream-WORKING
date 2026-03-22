using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using JetBrains.Annotations;

public class DialogueSpriteController : MonoBehaviour
{

    public Image leftSprite;
    public Image rightSprite;
    public List<Sprite> leftSprites = new List<Sprite>();
    public List<Sprite> rightSprites = new List<Sprite>();
    public Image cinematicBackground;
    public Image cinematic;
    public List<Sprite> cinematicSprites = new List<Sprite>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftSprite.sprite = leftSprites[0];
        
        rightSprite.sprite = rightSprites[0];

        cinematicBackground.sprite = cinematicSprites[0];
        cinematic.sprite = cinematicSprites[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLeftSprite(int spriteIndex)
    {
        rightSprite.sprite = rightSprites[0];
        cinematic.sprite = cinematicSprites[0];
        cinematicBackground.sprite = cinematicSprites[0];
        leftSprite.sprite = leftSprites[spriteIndex];
    }

    public void changeRightSprite(int spriteIndex)
    {
        rightSprite.sprite = rightSprites[spriteIndex];
        cinematic.sprite = cinematicSprites[0];
        cinematicBackground.sprite = cinematicSprites[0];
        leftSprite.sprite = leftSprites[0];
    }

    public void clearSprites()
    {
        rightSprite.sprite = rightSprites[0];
        leftSprite.sprite= leftSprites[0];
        cinematic.sprite = cinematicSprites[0];
        cinematicBackground.sprite = cinematicSprites[0];
    }

    public void changeCinematicSprites(int spriteIndex)
    {
        rightSprite.sprite = rightSprites[0];
        leftSprite.sprite = leftSprites[0];
        cinematicBackground.sprite = cinematicSprites[1];
        cinematic.sprite = cinematicSprites[spriteIndex];
    }

}
