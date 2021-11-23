using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CreateRaycastRed : MonoBehaviour
{
    public static CreateRaycastRed instance;
    //public GameObject firePoint;
    //public GameObject bullet;
    //private LineRenderer lr;
    //public float range;
    //public int redTotalBullets;
   // public bool redCanShoot;
    //public List<GameObject> redBulletsInScene = null;
    //public float time;
    //public float fq;
    //[SerializeField] private GameObject fp;
    //[SerializeField] private GameObject holder;
    public bool mustReload;
    public bool reloaded;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
      //  lr = gameObject.GetComponent<LineRenderer>();
       // redCanShoot = false;
        //for(int i = 0; i < redTotalBullets; i++)
        //{
        //    redBulletsInScene.Add(bullet);
        //}
      //  fp = GameObject.FindGameObjectWithTag("RedFirePoint");
       // holder = GameObject.FindGameObjectWithTag("Hold");
        mustReload = false;
        reloaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //RaycastHit hit;
        //if (!mustReload)
        //{
        //    if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        //    {

        //        if (hit.transform.tag == "Blue")
        //        {
        //            lr.SetPosition(0, firePoint.transform.position);
        //            lr.SetPosition(1, hit.transform.position);
        //            redCanShoot = true;
        //        }
        //        else
        //        {
        //            redCanShoot = false;
        //        }
        //        if (redCanShoot)
        //        {
        //            RedShoot();
        //        }
        //    }
        //}
        if (RedFinalShoot.instance.redBulletsInScene.Count == 0)
        {
            
            Debug.Log("Red Must Reload");
            mustReload = true;
        }
        if(reloaded)
        {
            RedReload.instance.readyToGo = false;
            for (int i = 0; i < RedFinalShoot.instance.redTotalBullets; i++)
            {
                RedFinalShoot.instance.redBulletsInScene.Add(RedFinalShoot.instance.bullet);
            }
            RedReload.instance.readyToGo = true;
            reloaded = false;
            mustReload = false;
            RedTankMovement.instance.time = 0;
        }
    }

    //void RedShoot()
    //{
    //    for (int i = 0; i <= redTotalBullets; i++)
    //    {
    //        if (time >= fq)
    //        {
    //            time = 0f;
    //            Instantiate(redBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
    //            redBulletsInScene.RemoveAt(i);
    //        }
    //    }
    //}
}
