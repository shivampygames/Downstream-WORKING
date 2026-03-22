using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum GameState { backstory, lvl001 /* first dialogue */, lvl002 /* first fishing wait until caught 10 fish*/, lvl003 /*interruption lol with the people*/, lvl004 /*pop up with the daytime timer thing*/, lvl005 /*go back to fishing with the newly added daytime timer*/, lvl006 /*go talk to dad (AT THIS POINT HE EATS THE FISH)*/, lvl007 /*eachnightlasts1minutetextboxpopup*/, lvl008 /*monstergamething*/, lvl009 /*go talk to dad*/, lvl010 /*go sleep*/ }

    public GameState currentState;

    public bool readyForLevel2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = GameState.backstory;
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


        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState =  GameState.lvl001;
        }

    }
    private void lvl001()
    {
        readyForLevel2 = false;
        Debug.Log("omg level 1 ltes go");

        if (readyForLevel2 == true)
        {
            currentState = GameState.lvl002;
        }

    }

    private void lvl002()
    {
        Debug.Log("ong we r in lvl 2 lol");
    }


}
