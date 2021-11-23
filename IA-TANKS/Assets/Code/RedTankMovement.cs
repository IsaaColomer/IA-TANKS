using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

public class RedTankMovement : MonoBehaviour
{
    public static RedTankMovement instance;
    private NavMeshAgent agent;
    [SerializeField] private GameObject redReloadPos;
    [SerializeField] public float time;
    [SerializeField] public float reloadTime;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        agent = gameObject.GetComponent<NavMeshAgent>();
        redReloadPos = GameObject.FindGameObjectWithTag("RedReloadPoint");
        time = 0;
    }

    // Update is called once per frame
    bool Update()
    {
        bool ret = true;
        if(!CreateRaycastRed.instance.mustReload)
        {
            Wander();
            ret = false;
        }
        else
        {
            agent.destination = redReloadPos.transform.position;
            ret = true;
        }
        return ret;
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
            transform.TransformPoint(localTarget);
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
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("RedReloadPos")&&CreateRaycastRed.instance.mustReload)
        {
            
            if(time > reloadTime)
            {
                CreateRaycastRed.instance.reloaded = true;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }
}
