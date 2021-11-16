using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycast : MonoBehaviour
{
    public GameObject firePoint;
    private LineRenderer lr;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
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

                Instantiate(BlueTankBullet.instace.bulletPrefab, BlueTankBullet.instace.spawnPositionBlue.transform.position, Quaternion.identity, BlueTankBullet.instace.bulletHolder.transform);
            } 
            if(hit.transform.tag == "Blue")
            {
                lr.SetPosition(0, firePoint.transform.position);
                lr.SetPosition(1, hit.transform.position);

                Instantiate(RedTankSpawnBullets.instace.bulletPrefab, RedTankSpawnBullets.instace.spawnPositionRed.transform.position, Quaternion.identity, RedTankSpawnBullets.instace.bulletHolder.transform);
            }
        }
    }
}
