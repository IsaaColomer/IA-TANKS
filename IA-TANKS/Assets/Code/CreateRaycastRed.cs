using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRaycastRed : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    private LineRenderer lr;
    public float range;
    public int redTotalBullets;
    public bool redCanShoot;
    public List<GameObject> redBulletsInScene = null;
    public float time;
    public float fq;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        redCanShoot = false;
        for(int i = 0; i < redTotalBullets; i++)
        {
            redBulletsInScene.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        RaycastHit hit;
        if (Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Blue")
            {
                lr.SetPosition(0, firePoint.transform.position);
                lr.SetPosition(1, hit.transform.position);
                redCanShoot = true;

            }
            else
            {
                redCanShoot = false;
            }
            if (redCanShoot)
            {
                RedShoot();
            }
        }
        if (redBulletsInScene.Count == 0)
        {
            Debug.Log("Red Must Reload");
        }
    }

    void RedShoot()
    {
        for (int i = 0; i <= redTotalBullets; i++)
        {
            if (time >= fq)
            {
                time = 0f;
                Instantiate(redBulletsInScene[i], RedTankSpawnBullets.instace.spawnPositionRed.transform.position, Quaternion.identity, RedTankSpawnBullets.instace.bulletHolder.transform);
                redBulletsInScene.RemoveAt(i);
            }
        }
    }
}
