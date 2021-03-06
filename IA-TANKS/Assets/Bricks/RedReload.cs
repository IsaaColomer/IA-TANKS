using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;

[Action("MyActions/Reloading")]
public class RedReload : BasePrimitiveAction
{
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("TankWander")]
    public GameObject rt;
    [InParam("ReloadPos")]
    [SerializeField] public Transform redReloadPos;
    public bool readyToGo;

    [InParam("ReloadTime")]
    public float Reloadtime;
    public float time;
    public static RedReload instance;
    // Start is called before the first frame update
    public override void OnStart()
    {
        instance = this;
        readyToGo = false;
        redReloadPos = GameObject.FindGameObjectWithTag("RedReloadPoint").transform;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().m = false;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().r = true;
        GameObject.Find("Red").GetComponent<UIelementsHighlight>().s = false;
    }

    // Update is called once per frame
    public override TaskStatus OnUpdate()
    {
        GameObject.Find("Debug").GetComponent<DebugInfo>().candebug = false;
        if (!readyToGo && CreateRaycastRed.instance.mustReload)
        {
            agent.destination = redReloadPos.position;
            return TaskStatus.FAILED;
        }
        else
        {
            return TaskStatus.COMPLETED;
        }
    }
}
