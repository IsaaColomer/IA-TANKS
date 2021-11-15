using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookEnemy : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 look = new Vector3(enemy.transform.position.x, transform.position.y, enemy.transform.position.z);
        transform.LookAt(look);
    }
}
