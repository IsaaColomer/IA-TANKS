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
    [InParam("minDistance")]
    public float d;
    [InParam("thisTank")]
    public GameObject r;
    [InParam("enemyTank")]
    public GameObject b;
    public void Start()
    {
        instance = this;
    }
    public override bool Check()
    {
        bool ret = false;
        //RaycastHit hit;
        //if (Physics.Raycast(fp.transform.position, fp.transform.forward, out hit, range))
        //{
        //    if (hit.transform.tag == "Blue" || hit.transform.tag == "BlueFirePoint")
        //    {
        //        Debug.Log("Seen");
        //        ret = true;
        //        Debug.DrawLine(fp.transform.position, hit.transform.position, Color.red);
        //    }
        //    else
        //    {
        //        Debug.Log("Not seen");
        //        ret = false;
        //        Debug.DrawLine(fp.transform.position, hit.transform.position, Color.green);
        //    }
        //}
        float dx = b.transform.position.x - r.transform.position.x;
        float dz = b.transform.position.z - r.transform.position.z;
        Vector2 distance = new Vector2(dx, dz);
        Debug.Log(GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Count);
        if(distance.magnitude<d && GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

        return ret;
    }
}
