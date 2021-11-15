using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTankSpawnBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public static RedTankSpawnBullets instace;
    public GameObject enemy;
    public GameObject spawnPositionRed;
    public GameObject bulletPrefab;
    public float time;
    public GameObject bulletHolder;
    public void Start()
    {
        instace = this;
        spawnPositionRed = GameObject.FindGameObjectWithTag("RedFirePoint");
        time = 0;
    }
    public void Update()
    {
        if (time < 2)
        {
            time += Time.deltaTime;
        }
        if (time > 2)
        {
            Instantiate(bulletPrefab, spawnPositionRed.transform.position, Quaternion.identity, bulletHolder.transform);
            time = 0;
        }
    }
}
