using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycast : MonoBehaviour
{
    public static CreateRaycast instance;
    public GameObject firePoint;
    private LineRenderer lr;
    public float range;
    public int blueTotalBullets;
    public int redTotalBullets;
    public float blueTime;
    public float redTime;
    public bool blueCanShoot;
    public bool redCanShoot;
    public List<GameObject> blueBulletsInScene = null;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        lr = gameObject.GetComponent<LineRenderer>();
        blueTotalBullets = 3;
        redTotalBullets = 3;
        blueCanShoot = false;
        redCanShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            if(hit.transform.tag == "Blue")
            {
                lr.SetPosition(0, firePoint.transform.position);
                lr.SetPosition(1, hit.transform.position);

                Instantiate(RedTankSpawnBullets.instace.bulletPrefab, RedTankSpawnBullets.instace.spawnPositionRed.transform.position, Quaternion.identity, RedTankSpawnBullets.instace.bulletHolder.transform);
            }

            if(blueCanShoot&&blueTime<=0)
            {
                BlueShoot();
            }
        }
    }

    void BlueShoot()
    {
        if(blueBulletsInScene.Count != blueTotalBullets)
        {
            blueBulletsInScene.Add(Instantiate(BlueTankBullet.instace.bulletPrefab, BlueTankBullet.instace.spawnPositionBlue.transform.position, Quaternion.identity, BlueTankBullet.instace.bulletHolder.transform));
        }
        
    }
}
