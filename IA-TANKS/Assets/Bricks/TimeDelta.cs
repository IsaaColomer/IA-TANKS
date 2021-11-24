using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelta : MonoBehaviour
{
    public static TimeDelta instance;
    public float time;
    public GameObject redbullet;
    public GameObject blueBullet;
    public GameObject[] waypoints;
    [SerializeField] private float bullets;
    [SerializeField] private float bluebullets;
    public List<GameObject> redBulletsInScene = null;
    public List<GameObject> blueBulletsInScene = null;
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
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bullets = redBulletsInScene.Count;
        bluebullets = blueBulletsInScene.Count;
    }
}
