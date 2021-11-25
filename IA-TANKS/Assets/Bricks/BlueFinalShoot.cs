using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; //
[Action("MyActions/BlueShoot")]
public class BlueFinalShoot : BasePrimitiveAction
{
    public static BlueFinalShoot instance;
    [InParam("FirePoint")]
    public GameObject fp;
    [InParam("BulletHolder")]
    public GameObject holder;
    [InParam("BluieBulletPrefab")]
    public GameObject bullet;
    public int blueTotalBullets;
    public float fq;
    // Start is called before the first frame update
    public override void OnStart()
    {
        instance = this;
        blueTotalBullets = 5;
        fq = 2f;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().m = false;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().r = false;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().s = true;
    }
    public override TaskStatus OnUpdate()
    {
        BlueShoot();
        return TaskStatus.RUNNING;
    }
    void BlueShoot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (TimeDelta.instance.timeBlue >= fq)
            {
                TimeDelta.instance.timeBlue = 0f;
                GameObject.Instantiate(GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
                GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.RemoveAt(i);
            }
        }
    }
}
