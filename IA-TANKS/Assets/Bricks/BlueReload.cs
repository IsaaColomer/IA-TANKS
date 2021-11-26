using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction
using UnityEngine.AI;
[Action("MyActions/BlueReloading")]
public class BlueReload : BasePrimitiveAction
{
    [InParam("NavMesh")]
    public NavMeshAgent agent;
    [InParam("TankWander")]
    public GameObject rt;
    [InParam("BlueReloadPos")]
    [SerializeField] public Transform blueReloadPos;
    public bool readyToGo;

    [InParam("ReloadTime")]
    public float Reloadtime;
    public float time;
    public static BlueReload instance;
    public override void OnStart()
    {
        instance = this;
        readyToGo = false;
        blueReloadPos = GameObject.FindGameObjectWithTag("BlueReloadPoint").transform;

        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().m = false;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().r = true;
        GameObject.Find("Blue").GetComponent<UIelementsHighlight>().s = false;
    }

    public override TaskStatus OnUpdate()
    {
        GameObject.Find("Debug").GetComponent<DebugInfo>().candebug = false;
        if (!readyToGo && CreateRaycastBlue.instance.mustReload)
        {
            agent.destination = blueReloadPos.position;
            return TaskStatus.FAILED;
        }
        else
        {
            return TaskStatus.COMPLETED;
        }
    }

}
