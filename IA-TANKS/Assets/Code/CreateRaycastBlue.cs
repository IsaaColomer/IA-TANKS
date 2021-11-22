using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycastBlue : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    private LineRenderer lr;
    public float range;
    public int blueTotalBullets;
    public bool blueCanShoot;
    public List<GameObject> blueBulletsInScene = null;
    public float time;
    public float fq;
    [SerializeField] private GameObject fp;
    [SerializeField] private GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        blueCanShoot = false;
        for(int i = 0; i<  blueTotalBullets; i++)
        {
            blueBulletsInScene.Add(bullet);
        }
        fp = GameObject.FindGameObjectWithTag("BlueFirePoint");
        holder = GameObject.FindGameObjectWithTag("Hold");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        RaycastHit hit;
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Red")
            {
                lr.SetPosition(0, firePoint.transform.position);
                lr.SetPosition(1, hit.transform.position);
                blueCanShoot = true;
                
            }
            else
            {
                blueCanShoot = false;
            }
            if(blueCanShoot)
            {
                BlueShoot();
            }
        }
        if(blueBulletsInScene.Count == 0)
        {
            Debug.Log("Blue Must Reload");
        }
    }

    void BlueShoot()
    {
     for (int i = 0; i <= blueTotalBullets; i++)
     {
            if (time >= fq)
            {
                time = 0f;
                Instantiate(blueBulletsInScene[i], fp.transform.position, Quaternion.identity, holder.transform);
                blueBulletsInScene.RemoveAt(i);
            }
    }
   }
}
