using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/WanderAction")]
public class WanderScript : BasePrimitiveAction
{
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("TankWander")]
    public GameObject rt;

    //public override void OnStart()
    //{
    //    instance = this;
    //    readyToGo = false;
    //    redReloadPos = GameObject.FindGameObjectWithTag("RedReloadPoint").transform;
    //}
    public override TaskStatus OnUpdate()
    {
            Wander();
            return TaskStatus.RUNNING;
    }
    void Wander()
    {
        float radius = 2f;
        float offset = 3f;
        Vector3 localTarget = new Vector3(
            Random.Range(-1.0f, 1.0f), 0,
            Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget =
            rt.transform.TransformPoint(localTarget);
        worldTarget.y = 0f;

        Vector3 result = Vector3.zero;
        NavMeshHit hit;
        for(int i = 0; i < GameObject.Find("Time").GetComponent<TimeDelta>().avoid.Length; i++)
        {
            if(!GameObject.Find("Time").GetComponent<TimeDelta>().avoid[i].GetComponent<BoxCollider>().bounds.Contains(localTarget))
            {
                Debug.Log("True");
                agent.destination = worldTarget;
            }
            else
            {
                Debug.Log("False");
                agent.destination = -worldTarget;
            }
        }
    }
}
