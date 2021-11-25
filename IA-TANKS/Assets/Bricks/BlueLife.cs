using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction


[Condition("BlueLife")]

public class BlueLife : ConditionBase
{
    [InParam("thisTank")]
    public GameObject r;

    public float blue;

    public void Start()
    {
        blue = GameObject.Find("Time").GetComponent<TimeDelta>().blueLife;
    }
    public override bool Check()
    {
        blue = GameObject.Find("Time").GetComponent<TimeDelta>().blueLife;
        bool ret = false;
        if (blue > 0)
        {
            ret = true;
        }
        return ret;
    }
}
