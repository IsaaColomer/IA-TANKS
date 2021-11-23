using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Condition("MyConditions/RedCheckEmpty")]
public class CheckRedEmptyMagazine : ConditionBase
{
    public override bool Check()
    {
        bool ret = true;
        if(RedFinalShoot.instance.redBulletsInScene.Count == 0)
        {
            return false;
        }            

        return ret;
    }
}
