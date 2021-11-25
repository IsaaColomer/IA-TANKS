using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlueTankMovement : MonoBehaviour
{
    public static BlueTankMovement instance;
    [SerializeField] public float time;
    void Start()
    {
        instance = this;
        time = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("BlueReloadPos") && CreateRaycastBlue.instance.mustReload)
        {
            if (time > BlueReload.instance.Reloadtime)
            {
                CreateRaycastBlue.instance.reloaded = true;
            }
            else
            {
                time += Time.deltaTime;
            }
        }
    }
}
