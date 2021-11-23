using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Condition("MyCondition/OneTime")]
public class DoOnly1Time : ConditionBase
{
    // Start is called before the first frame update
    public override bool Check()
    {
        bool ret = true;
        if(this != null)
        {
            Debug.Log("Done");
            ret = false;
        }

        return ret;
    }
}
