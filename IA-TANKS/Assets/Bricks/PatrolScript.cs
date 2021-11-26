using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/PatrolAction")]
public class PatrolScript : BasePrimitiveAction
{
    public static PatrolScript instace;
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("BlueTankWander")]
    public GameObject rt;
    public GameObject[] waypoints = new GameObject[12];
    public int patrolWP = 0;
    // Start is called before the first frame update
    public override void OnStart()
    {
        instace = this;
        for (int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("Time").GetComponent<TimeDelta>().waypoints2[i];
            GameObject.Find("Debug").GetComponent<DebugInfo>().pp[i].SetActive(false);
        }
        GameObject.Find("Debug").GetComponent<DebugInfo>().candebug = true;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().m = true;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().r = false;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().s = false;
        GameObject.Find("Debug").GetComponent<DebugInfo>().selected = 0;
    }
    public override TaskStatus OnUpdate()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
        return TaskStatus.RUNNING;
    }
    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        GameObject.Find("Debug").GetComponent<DebugInfo>().selected = patrolWP;
        agent.destination = waypoints[patrolWP].transform.position;
    }
}
