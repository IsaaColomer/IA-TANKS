using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public static ProjectileShooting instace;
    public GameObject enemy;
    public GameObject spawnPosition;
    public GameObject bulletPrefab;
    public float time;
    public float v;
    public float angle;
    public GameObject bulletHolder;
    public void Start()
    {
        instace = this;
        time = 0;
    }
    public void Update()
    {
        if(time <2)
        {
            time += Time.deltaTime;
        }
        if(time >2)
        {
            Instantiate(bulletPrefab, spawnPosition.transform.position, Quaternion.identity, bulletHolder.transform);
            time = 0;
        }
    }
}
