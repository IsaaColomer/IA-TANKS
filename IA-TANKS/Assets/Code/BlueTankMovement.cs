using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueTankMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject[] waypoints;
    int patrolWP = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
    }


void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        agent.destination = waypoints[patrolWP].transform.position;
    }
}
