using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTankBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public static BlueTankBullet instace;
    public GameObject enemy;
    public GameObject spawnPositionBlue;
    public GameObject bulletHolder;
    public void Start()
    {
        instace = this;
        spawnPositionBlue = GameObject.FindGameObjectWithTag("BlueFirePoint");
    }
    public void Update()
    {

    }
}
