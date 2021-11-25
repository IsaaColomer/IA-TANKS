using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
[Condition("RedLife")]
public class RedLife : ConditionBase
{
    [InParam("thisTank")]
    public GameObject r;

    public float red;

    public void Start()
    {
        red = GameObject.Find("Time").GetComponent<TimeDelta>().redLife;
    }
    public override bool Check()
    {
        red = GameObject.Find("Time").GetComponent<TimeDelta>().redLife;
        bool ret = false;
        if (red > 0)
        {
            ret = true;
        }
        return ret;
    }
}
