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
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("BlueTankWander")]
    public GameObject rt;
    public GameObject[] waypoints = new GameObject[12];
    int patrolWP = 0;
    // Start is called before the first frame update
    public override void OnStart()
    {
        for (int i = 0; i<waypoints.Length; i++)
        {
            waypoints[i] = GameObject.Find("Time").GetComponent<TimeDelta>().waypoints2[i];
        }
    }
    public override TaskStatus OnUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
        return TaskStatus.RUNNING;
    }
    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        agent.destination = waypoints[patrolWP].transform.position;
    }
}
