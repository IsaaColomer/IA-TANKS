using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Framework; // ConditionBase

[Condition("MyConditions/CanISeeTheEnemy")]
public class CanSeeEnemy : ConditionBase
{
    [InParam("tank")]
    public GameObject fp;
    [InParam("range")]
    public float range;
    public override bool Check()
    {
        bool ret = false;
        RaycastHit hit;
        if (Physics.Raycast(fp.transform.position, fp.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Red")
            {
                ret = true;

            }
            else
            {
                ret = false;
            }
        }
        Debug.DrawLine(fp.transform.position, hit.transform.position, Color.green);
        return ret;
    }
}
