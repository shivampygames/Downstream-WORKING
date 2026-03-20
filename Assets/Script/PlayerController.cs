using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController cc;

    float gravityMultiplier = 20f;

    private float moveSpeed;
    private float spinSpeed;

    float verticalRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        moveSpeed = 3f;
        spinSpeed = 25f;


    }

    // Update is called once per frame
    void Update()
    {

        float inputLR = Input.GetAxisRaw("Horizontal");
        float inputF = Input.GetAxisRaw("Vertical");
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        Vector3 move = new Vector3(inputLR, 0, inputF);

        move.y -= gravityMultiplier * Time.deltaTime;

        move = (transform.TransformDirection(move)).normalized * moveSpeed * Time.deltaTime;

        cc.Move(move);

        float rotateAmount = mouseX * spinSpeed;

        Quaternion currentSpin = transform.localRotation;
        Quaternion targetSpin = transform.rotation * Quaternion.Euler(0, rotateAmount, 0);

        transform.rotation = Quaternion.Slerp(currentSpin, targetSpin, Time.deltaTime * 4f); // 4f is the spin speed 

        verticalRotation -= mouseY * spinSpeed;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        transform.Rotate(verticalRotation, 0, 0);



        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


    }
}


