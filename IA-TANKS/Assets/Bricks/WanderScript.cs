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
    public static WanderScript instance;
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("TankWander")]
    public GameObject rt;
    [InParam("ShootPoint")]
    public GameObject sp;
    bool doWander = true;
    public Vector3 worldTarget;
    public override void OnStart()
    {
        instance = this;
        GameObject.Find("Debug").GetComponent<DebugInfo>().wt.transform.position = worldTarget;
        GameObject.Find("Debug").GetComponent<DebugInfo>().wt.SetActive(false);
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().m = true;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().r = false;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().s = false;
    }
    public override TaskStatus OnUpdate()
    {
        GameObject.Find("Debug").GetComponent<DebugInfo>().candebug = true;
        if (doWander)
        {
            Wander();
        }
            TRay();


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
        worldTarget =
            rt.transform.TransformPoint(localTarget);
        worldTarget.y = 0f;
        GameObject.Find("Debug").GetComponent<DebugInfo>().wt.transform.position = worldTarget;
        GameObject.Find("Time").GetComponent<TimeDelta>().local.transform.position = worldTarget;
        for (int i = 0; i < GameObject.Find("Time").GetComponent<TimeDelta>().avoid.Length; i++)
        {
                if (!GameObject.Find("Time").GetComponent<TimeDelta>().avoid[i].GetComponent<BoxCollider>().bounds.Contains(localTarget))
                {
                    agent.destination = worldTarget;
                    GameObject.Find("Time").GetComponent<TimeDelta>().timeBlue = 0;
                }
                else
                {
                    agent.destination = -worldTarget;
                    GameObject.Find("Time").GetComponent<TimeDelta>().timeBlue = 0;
                }
        }
    }
    void TRay()
    {
        RaycastHit hit;
        if(Physics.Raycast(sp.transform.position, sp.transform.forward, out hit, 2))
        {
            if(hit.transform.tag != "Blue" || hit.transform.tag != "BlueFirePoint")
            {
                doWander = false;
                agent.destination = new Vector3(-agent.transform.forward.x, 0f, -agent.transform.forward.z) * 7;
            }
            else
            {
                doWander = true;
            }
        }
        else
        {
            doWander = true;
        }
    }
}

