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
    [InParam("FirePoint")]
    public GameObject fp;
    [InParam("BulletHolder")]
    public GameObject holder;
    [InParam("RedBulletPrefab")]
    public GameObject bullet;

    public float time;
    public float fq;

    List<GameObject> redBulletsInScene = null;

    private int redTotalBullets;
    // Start is called before the first frame update
    public override void OnStart()
    {
        redBulletsInScene = new List<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            redBulletsInScene.Add(bullet);
        }
        fq = 3f;
    }

    public override TaskStatus OnUpdate()
    {
        time += Time.deltaTime;
        RedShoot();
        return TaskStatus.RUNNING;
    }

    void RedShoot()
    {
        for (int i = 0; i < 5; i++)
        {
            if (time >= fq)
            {
                time = 0f;
                
                GameObject.Instantiate(redBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
                redBulletsInScene.RemoveAt(i);
            }
        }
    }
}
