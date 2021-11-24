using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycastBlue : MonoBehaviour
{
    public static CreateRaycastBlue instance;
    //public GameObject firePoint;
    //public GameObject bullet;
    //public float range;
    //public int blueTotalBullets;
    //public bool blueCanShoot;
    //public List<GameObject> blueBulletsInScene = null;
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
        //blueCanShoot = false;
        //for(int i = 0; i<  blueTotalBullets; i++)
        //{
        //    blueBulletsInScene.Add(bullet);
        //}
        //fp = GameObject.FindGameObjectWithTag("BlueFirePoint");
        //holder = GameObject.FindGameObjectWithTag("Hold");
        mustReload = false;
        reloaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //time += Time.deltaTime;
        //RaycastHit hit;
        //if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        //{
        //    if (hit.transform.tag == "Red")
        //    {
        //        blueCanShoot = true;

        //    }
        //    else
        //    {
        //        blueCanShoot = false;
        //    }
        //    if(blueCanShoot)
        //    {
        //        BlueShoot();
        //    }
        //}
        //if(blueBulletsInScene.Count == 0)
        //{
        //    Debug.Log("Blue Must Reload");
        //    mustReload = true;
        //}
        if (GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Count == 0)
        {
            mustReload = true;
        }
        if (reloaded)
        {
            BlueReload.instance.readyToGo = false;
            for (int i = 0; i < BlueFinalShoot.instance.blueTotalBullets; i++)
            {
                GameObject.Find("Time").GetComponent<TimeDelta>().blueBulletsInScene.Add(BlueFinalShoot.instance.bullet);
            }
            BlueReload.instance.readyToGo = true;
            reloaded = false;
            mustReload = false;
            BlueTankMovement.instance.time = 0;
        }
    }

    //void BlueShoot()
    //{
    // for (int i = 0; i <= BlueFinalShoot.instance.blueTotalBullets; i++)
    //    {
    //        if (time >= fq)
    //        {
    //            time = 0f;
    //            Instantiate(blueBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
    //            blueBulletsInScene.RemoveAt(i);
    //        }
    //    }
    //}
}
