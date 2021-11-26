using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public Camera redTankCamera;
    public Camera blueTankCamera;
    public Camera generalCamera;
    // Start is called before the first frame update
    void Start()
    {
        redTankCamera.enabled = false;
        blueTankCamera.enabled = false;
        generalCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            redTankCamera.enabled = false;
            blueTankCamera.enabled = false;
            generalCamera.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            redTankCamera.enabled = true;
            blueTankCamera.enabled = false;
            generalCamera.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            redTankCamera.enabled = false;
            blueTankCamera.enabled = true;
            generalCamera.enabled = false;
        }
    }
}
