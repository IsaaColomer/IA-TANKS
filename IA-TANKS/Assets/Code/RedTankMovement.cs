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
    [SerializeField] public float time;
    void Start()
    {
        instance = this;
        time = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("RedReloadPos")&&CreateRaycastRed.instance.mustReload)
        {            
            if(time > RedReload.instance.Reloadtime)
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
