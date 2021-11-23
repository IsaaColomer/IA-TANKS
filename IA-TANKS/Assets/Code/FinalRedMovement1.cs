using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
[Action("MyActions/aasdasdsad")]
public class FinalRedMovement1 : BasePrimitiveAction
{
    [InParam("navMeshAgent")]
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Wander()
    {
       /* float radius = 2f;
        float offset = 3f;
        Vector3 localTarget = new Vector3(
            Random.Range(-1.0f, 1.0f), 0,
            Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget =
           // this.gameObject.transform.TransformPoint(localTarget);
        //worldTarget.y = 0f;

        Vector3 result = Vector3.zero;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(worldTarget, out hit, 1.0f, NavMesh.GetAreaFromName("Not Walkable")))
        {
            agent.destination = worldTarget;
        }
        else
        {
            agent.destination = -worldTarget;
        }*/

    }
}
