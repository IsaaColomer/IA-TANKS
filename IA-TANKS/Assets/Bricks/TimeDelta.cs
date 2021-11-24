using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelta : MonoBehaviour
{
    public static TimeDelta instance;
    public float time;
    public GameObject redbullet;
    [SerializeField] private float bullets;
    public List<GameObject> redBulletsInScene = null;
    public void AddBullets()
    {
        for (int i = 0; i < 5; i++)
        {
            redBulletsInScene.Add(redbullet);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        redBulletsInScene = new List<GameObject>();
        AddBullets();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bullets = redBulletsInScene.Count;
    }


}
