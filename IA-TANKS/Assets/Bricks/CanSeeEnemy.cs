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
        float dx = b.transform.position.x - r.transform.position.x;
        float dz = b.transform.position.z - r.transform.position.z;
        Vector2 distance = new Vector2(dx, dz);
        if(distance.magnitude<d && GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
