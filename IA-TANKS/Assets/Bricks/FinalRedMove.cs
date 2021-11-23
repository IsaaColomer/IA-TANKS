using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
[Action("MyActions/RedMove")]
public class FinalRedMove : BasePrimitiveAction
{
    [InParam("navMeshAgent")]
    public NavMeshAgent agent;

    [InParam("RedTank")]
    public GameObject RT;

    [InParam("EmptyMagazine")]
    public bool reload;
    public void Wander()
    {
        float radius = 2f;
        float offset = 3f;
        Vector3 localTarget = new Vector3(
            Random.Range(-1.0f, 1.0f), 0,
            Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = RT.transform.TransformPoint(localTarget);
        worldTarget.y = 0f;

        Vector3 result = Vector3.zero;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(worldTarget, out hit, 1.0f, NavMesh.GetAreaFromName("Not Walkable")))
        {
            agent.destination = worldTarget;
        }
        else
        {
            agent.destination = -worldTarget;
        }

    }
}
