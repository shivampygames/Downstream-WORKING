using Invector.vCharacterController;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public vThirdPersonInput vThirdPersonInput;
    public vThirdPersonCamera vThirdPersonCamera;
    public vThirdPersonController vThirdPersonController;
    public Animator animator;

    public GameManager gameManager;

    private bool setLevelOne = false;
    private bool setLevelEight = false;
    private bool controlsAreEnabled = true;
    private bool setLevel11 = false;
    private bool setLevel14 = false;
    private bool setLevel18 = false;
    private bool setLevel22 = false;
    private bool setLevel28 = false;
    private bool setLevel25 = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.currentState == GameManager.GameState.backstory)
        {
            //controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl001)
        {
            controls();

            if (setLevelOne == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevelOne = true;
            }

        }
        else if (gameManager.currentState == GameManager.GameState.lvl002andahalf)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl002)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl005)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl006)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl007)
        {
            controls();
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controlsAreEnabled = false;

        }
        else if (gameManager.currentState == GameManager.GameState.lvl008)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();

            if (setLevelEight == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevelEight = true;
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl009)
        {
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl010)
        {
            controls();
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;

        }
        else if (gameManager.currentState == GameManager.GameState.lvl011)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();

            if (setLevel11 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel11 = true;
            }

        }
        else if (gameManager.currentState == GameManager.GameState.lvl011)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl012)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl013)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl014)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();

            if (setLevel14 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel14 = true;
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl015)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl016)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl017)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl018)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();

            if (setLevel18 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel18 = true;
            }

        }
        else if (gameManager.currentState == GameManager.GameState.lvl019)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl020)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl021)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl022)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();

            if (setLevel22 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel22 = true;
            }
        }
        else if (gameManager.currentState == GameManager.GameState.lvl023)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl023)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl024)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl025)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
            if (setLevel25 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel25 = true;
            }

        }
        else if (gameManager.currentState == GameManager.GameState.lvl026)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl027)
        {
            controlsAreEnabled = false;
            vThirdPersonInput.enabled = false;
            controls();
        }
        else if (gameManager.currentState == GameManager.GameState.lvl028)
        {
            controlsAreEnabled = true;
            vThirdPersonInput.enabled = true;
            controls();
            if (setLevel28 == false)
            {
                transform.position = new Vector3(-5.34f, 0, 13.383f);

                transform.rotation = Quaternion.Euler((new Vector3(0, 0, 0)));
                setLevel28 = true;
            }
        }

        void controls()
        {
            if (Input.GetKey(KeyCode.Mouse1) && (controlsAreEnabled))
            {
                if (vThirdPersonCamera.lockCamera == true)
                {
                    vThirdPersonCamera.lockCamera = false;
                }
                if (Cursor.lockState == CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                /*
                if (vThirdPersonController.freeSpeed.rotationSpeed == 2.16f)
                {
                    vThirdPersonController.freeSpeed.rotationSpeed = 17f;
                }
                */
                if (vThirdPersonInput.enabled == false)
                {
                    vThirdPersonInput.enabled = true;
                }
            }
            else
            {
                if (vThirdPersonCamera.lockCamera == false)
                {
                    vThirdPersonCamera.lockCamera = true;
                }
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                /*
                if (vThirdPersonController.freeSpeed.rotationSpeed == 17f)
                {
                    vThirdPersonController.freeSpeed.rotationSpeed = 2.16f;
                }
                */
                if (vThirdPersonInput.enabled == true)
                {
                    vThirdPersonInput.enabled = false;
                }

            }

            // animations

            if ((Input.GetKey(KeyCode.W) == true) || (Input.GetKey(KeyCode.A) == true) || (Input.GetKey(KeyCode.S) == true) || (Input.GetKey(KeyCode.D) == true))
            {

                if (Input.GetKey(KeyCode.Mouse1) == true)
                {

                    if ((Input.GetKey(KeyCode.LeftShift) == true) || (Input.GetKey(KeyCode.RightShift) == true))
                    {
                        animator.SetFloat("speed", 11f);
                    }
                    else
                    {
                        //animator.speed = 6.7f;
                        animator.SetFloat("speed", 6.7f);
                    }
                }
                else
                {
                    animator.SetFloat("speed", 2f);
                }
            }
            else
            {
                //animator.speed = 2.7f;
                animator.SetFloat("speed", 2f);
            }

        }
    }
}
