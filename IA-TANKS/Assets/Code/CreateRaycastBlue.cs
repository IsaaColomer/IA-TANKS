using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycastBlue : MonoBehaviour
{
    public static CreateRaycastBlue instance;
    public bool mustReload;
    public bool reloaded;
    void Start()
    {
        instance = this;
        mustReload = false;
        reloaded = false;
    }
    void Update()
    {
        if (GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Count == 0)
        {
            mustReload = true;
        }
        if (reloaded)
        {
            BlueReload.instance.readyToGo = false;
            for (int i = 0; i < BlueFinalShoot.instance.blueTotalBullets; i++)
            {
                GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Add(BlueFinalShoot.instance.bullet);
            }
            BlueReload.instance.readyToGo = true;
            reloaded = false;
            mustReload = false;
            BlueTankMovement.instance.time = 0;
        }
    }
}
