using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueTankMovement : MonoBehaviour
{
    public static BlueTankMovement instance;
    private NavMeshAgent agent;
    public GameObject[] waypoints;
    int patrolWP = 0;
    // Start is called before the first frame update

    // reload
    [SerializeField] private GameObject blueReloadPos;
    [SerializeField] public float time;
    void Start()
    {
        instance = this;
        agent = gameObject.GetComponent<NavMeshAgent>();
        blueReloadPos = GameObject.FindGameObjectWithTag("BlueReloadPoint");
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!CreateRaycastBlue.instance.mustReload)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f) Patrol();
        }
        else
        {
            agent.destination = blueReloadPos.transform.position;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BlueReloadPos") && CreateRaycastBlue.instance.mustReload)
        {
            if (time > 2)
            {
                CreateRaycastBlue.instance.reloaded = true;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }

    void Patrol()
    {
        patrolWP = (patrolWP + 1) % waypoints.Length;
        agent.destination = waypoints[patrolWP].transform.position;
    }
}
