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
    [InParam("ShootPoint")]
    public GameObject sp;
    bool doWander = true;
    public override void OnStart()
    {
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().m = true;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().r = false;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().s = false;
    }
    public override TaskStatus OnUpdate()
    {
        if(doWander)
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
        Vector3 worldTarget =
            rt.transform.TransformPoint(localTarget);
        worldTarget.y = 0f;

        Vector3 result = Vector3.zero;
        NavMeshHit hit;
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
                Debug.Log("Hitted");
                agent.destination = new Vector3(-agent.transform.forward.x, 0f, -agent.transform.forward.z) * 3;
            }
            else
            {
                doWander = true;
            }
            Debug.DrawLine(sp.transform.position, hit.transform.position, Color.green);
        }
        else
        {
            doWander = true;
        }
    }
    bool DoWander()
    {
        bool ret = false;

        if (GameObject.Find("Time").GetComponent<TimeDelta>().timeBlue >0.65f)
        {
            ret = true;
        }

        return ret;
    }
}

