using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CreateRaycastRed : MonoBehaviour
{
    public static CreateRaycastRed instance;

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
        if (GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Count == 0)
        {
            mustReload = true;
        }
        if(reloaded)
        {
            RedReload.instance.readyToGo = false;
            for (int i = 0; i < RedFinalShoot.instance.redTotalBullets; i++)
            {
                GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Add(RedFinalShoot.instance.bullet);
            }
            RedReload.instance.readyToGo = true;
            reloaded = false;
            mustReload = false;
            RedTankMovement.instance.time = 0;
        }
    }
}
