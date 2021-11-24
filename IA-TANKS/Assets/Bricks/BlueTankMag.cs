using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;
using Pada1.BBCore.Framework; // ConditionBase



[Condition("isBlueMagEmpty")]

public class BlueTankMag : ConditionBase
{
    // Start is called before the first frame update
    public static BlueTankMag instance;

    [InParam("minDistance")]
    public float d;
    [InParam("thisTank")]
    public GameObject b;
    [InParam("enemyTank")]
    public GameObject r;
    public void Start()
    {
        instance = this;
    }
    public override bool Check()
    {
        bool ret = true;
        if (GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Count == 0)
        {
            return false;
        }

        float dx = b.transform.position.x - r.transform.position.x;
        float dz = b.transform.position.z - r.transform.position.z;
        Vector2 distance = new Vector2(dx, dz);
        if (distance.magnitude <= d)
        {
            return false;
        }
        return ret;
    }
}
