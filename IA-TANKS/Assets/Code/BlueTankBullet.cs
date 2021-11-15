using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTankBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public static BlueTankBullet instace;
    public GameObject enemy;
    public GameObject spawnPositionBlue;
    public GameObject bulletPrefab;
    public float time;
    public GameObject bulletHolder;
    public void Start()
    {
        instace = this;
        spawnPositionBlue = GameObject.FindGameObjectWithTag("BlueFirePoint");
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
            Instantiate(bulletPrefab, spawnPositionBlue.transform.position, Quaternion.identity, bulletHolder.transform);
            time = 0;
        }
    }
}
