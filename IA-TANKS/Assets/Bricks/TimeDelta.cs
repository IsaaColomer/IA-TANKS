using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelta : MonoBehaviour
{
    public static TimeDelta instance;
    public float time;
    public float timeBlue;
    public float redLife;
    public float blueLife;
    public GameObject redbullet;
    public GameObject local;
    public GameObject blueBullet;
    public GameObject[] waypoints2;
    [SerializeField] private float bullets;
    [SerializeField] private float bluebullets;
    public List<GameObject> redBulletsInScene = null;
    public List<GameObject> blueBulletsInScene = null;

    public GameObject[] avoid = new GameObject[24];
    public float wanderTime = 0;
    public void AddBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            redBulletsInScene.Add(redbullet);
        }
    }
    public void AddBlueBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            blueBulletsInScene.Add(blueBullet);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        redBulletsInScene = new List<GameObject>();
        blueBulletsInScene = new List<GameObject>();
        AddBullets();
        AddBlueBullets();
        time = 0;
        timeBlue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeBlue += Time.deltaTime;
        wanderTime += Time.deltaTime;
        bullets = redBulletsInScene.Count;
        bluebullets = blueBulletsInScene.Count;
    }
}
