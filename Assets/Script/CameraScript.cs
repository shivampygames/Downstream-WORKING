using Unity.Cinemachine;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public CinemachineCamera[] cameras = new CinemachineCamera[2];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //cameras[1].Prioritize();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Alpha1))
        {
            cameras[0].Prioritize();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            cameras[1].Prioritize();
        }

    }
}
