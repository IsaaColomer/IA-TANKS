using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework; // ConditionBase
[Condition("canSeeEnemy")]
public class CanSeeEnemy : ConditionBase
{
    public static CanSeeEnemy instance;
    [InParam("range")]
    public float range;
    [InParam("FirePoint")]
    public GameObject fp;
    public void Start()
    {
        instance = this;
    }
    public override bool Check()
    {
        bool ret = false;
        RaycastHit hit;
        if (Physics.Raycast(fp.transform.position, fp.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Blue")
            {
                Debug.Log("Seen");
                ret = true;
                Debug.DrawLine(fp.transform.position, hit.transform.position, Color.red);
            }
            else
            {
                ret = false;
                Debug.DrawLine(fp.transform.position, hit.transform.position, Color.green);
            }

        }

        return ret;
    }
}
