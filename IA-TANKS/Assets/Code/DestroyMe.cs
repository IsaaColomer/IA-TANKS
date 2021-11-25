using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pada1.BBCore;           // Code attributes
using Pada1.BBCore.Tasks;     // TaskStatus
using Pada1.BBCore.Framework; // BasePrimitiveAction

[Action("MyActions/DestroyMe")]

public class DestroyMe : BasePrimitiveAction
{
    [InParam("ThisTank")]
    public GameObject t;
    public override TaskStatus OnUpdate()
    {
        t.gameObject.SetActive(false);
        return TaskStatus.RUNNING;
    }
}
