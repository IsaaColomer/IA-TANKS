using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSeeEnemy : MonoBehaviour
{
    public static CanSeeEnemy instance;
    private float range;
    private GameObject fp;
    public void Start()
    {
        instance = this;
        range = 200f;
        fp = GameObject.FindGameObjectWithTag("RedFirePoint");
    }
    public void Update()
    {
        Check();
    }
    public bool Check()
    {
        bool ret = false;
        RaycastHit hit;
        if (Physics.Raycast(fp.transform.position, fp.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Blue")
            {
                ret = true;
                Debug.DrawLine(fp.transform.position, hit.transform.position, Color.red);
            }
            else
            {
                ret = false;
                Debug.DrawLine(fp.transform.position, hit.transform.position, Color.green);
            }
            
        }

        return ret;
    }
}
