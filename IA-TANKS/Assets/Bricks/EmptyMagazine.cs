using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Condition("MyCondition/Reload")]
public class EmptyMagazine : ConditionBase
{
    // Start is called before the first frame update
    public override bool Check()
    {
        bool ret = true;
        if (RedFinalShoot.instance.redBulletsInScene.Count == 0)
        {
            return false;
        }
        else
        {
            ret = true;
        }

        return ret;
    }
}
