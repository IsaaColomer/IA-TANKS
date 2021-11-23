using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRedEmptyMagazine : MonoBehaviour
{
    public static CheckRedEmptyMagazine instance;
    public void Start()
    {
        instance = this;
    }
    public void Update()
    {
        Check();
    }
    public bool Check()
    {
        bool ret = true;
        if(RedFinalShoot.instance.redBulletsInScene.Count == 0)
        {
            return false;
        }            

        return ret;
    }
}
