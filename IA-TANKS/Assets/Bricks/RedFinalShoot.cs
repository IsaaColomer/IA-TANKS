using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/RedShoot")]
public class RedFinalShoot : BasePrimitiveAction
{
    public static RedFinalShoot instance;
    [InParam("FirePoint")]
    public GameObject fp;
    [InParam("BulletHolder")]
    public GameObject holder;
    [InParam("RedBulletPrefab")]
    public GameObject bullet;
    public int redTotalBullets;
    public float fq;

    // Start is called before the first frame update
    public override void OnStart()
    {
        instance = this;
        redTotalBullets = 5;
        fq = 2f;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().m = false;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().r = false;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().s = true;
    }
    public override TaskStatus OnUpdate()
    {
        RedShoot();
        return TaskStatus.RUNNING;
    }
    void RedShoot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (TimeDelta.instance.time >= fq)
            {
                TimeDelta.instance.time = 0f;
                GameObject.Instantiate(GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
                GameObject.Find("Time").GetComponent<TimeDelta>().redBulletsInScene.RemoveAt(i);
            }
        }
    }
}
