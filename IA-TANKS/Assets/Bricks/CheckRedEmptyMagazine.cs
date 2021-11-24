using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework; // ConditionBase

[Condition("isMagEmpty")]
public class CheckRedEmptyMagazine : ConditionBase
{
    public static CheckRedEmptyMagazine instance;
    public void Start()
    {
        instance = this;
    }
    public override bool Check()
    {
        bool ret = false;
        if (TimeDelta.instance.redBulletsInScene.Count == 0)
        {
            return true;
        }

        return ret;
    }
}
