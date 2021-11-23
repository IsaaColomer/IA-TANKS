using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelta : MonoBehaviour
{
    public static TimeDelta instance;
    public float time;
    [SerializeField] private float bullets;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        bullets = RedFinalShoot.instance.redBulletsInScene.Count;
    }
}
