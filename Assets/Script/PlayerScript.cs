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
        } else if (gameManager.currentState == GameManager.GameState.lvl003)
        {
            controls();
        } else if (gameManager.currentState == GameManager.GameState.lvl004)
        {
            controls();
        } else if (gameManager.currentState == GameManager.GameState.lvl005)
        {
            controls();
        }

        //controls ?

        

    }

    void controls()
    {
        if (Input.GetKey(KeyCode.Mouse1))
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
