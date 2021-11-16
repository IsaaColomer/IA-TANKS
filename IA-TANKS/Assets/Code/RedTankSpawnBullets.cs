using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTankSpawnBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public static RedTankSpawnBullets instace;
    public GameObject enemy;
    public GameObject spawnPositionRed;
    public GameObject bulletHolder;
    public void Start()
    {
        instace = this;
        spawnPositionRed = GameObject.FindGameObjectWithTag("RedFirePoint");
    }
    public void Update()
    {
    }
}
