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

    public List<GameObject> redBulletsInScene = null;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            redBulletsInScene.Add(bullet);
        }
        Debug.Log("asd");
    }
    // Start is called before the first frame update
    public override void OnStart()
    {
        instance = this;
        redTotalBullets = 5;
        redBulletsInScene = new List<GameObject>();
        Start();
        fq = 2f;
    }
    public bool Update()
    {
        bool ret = false;
        if (CheckRedEmptyMagazine.instance.Check())
        {
            ret = true;
        }
        else
        {
            Debug.Log("aaa");
            if (CanSeeEnemy.instance.Check())
            {
                RedShoot();
                Debug.Log("bbb");
            }
            ret = false;
        }

        return ret;
    }
    public override TaskStatus OnUpdate()
    {
        if (!Update())
        {
            return TaskStatus.FAILED;
        }
        else
        {
            return TaskStatus.COMPLETED;
        }

    }
    void RedShoot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (TimeDelta.instance.time >= fq)
            {
                TimeDelta.instance.time = 0f;
                Debug.Log("a");
                GameObject.Instantiate(redBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
                redBulletsInScene.RemoveAt(i);
            }
        }
    }
}
