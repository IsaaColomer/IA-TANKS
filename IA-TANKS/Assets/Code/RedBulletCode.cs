using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private Vector2 velocity = new Vector2(10f, 10f);
    private Transform blueTank;
    private Vector2 updateVector;
    private float arrel;
    private Vector3 targetXZPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        blueTank = GameObject.FindGameObjectWithTag("Blue").transform;
        
        time = 0;
        transform.LookAt(blueTank.transform.position);
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.LookAt(blueTank.transform.position);
    }
    void Launch()
    {
        Vector3 projectileXZPos = new Vector3(RedTankSpawnBullets.instace.spawnPositionRed.transform.position.x, 0.0f, RedTankSpawnBullets.instace.spawnPositionRed.transform.position.z);
        targetXZPos = new Vector3(blueTank.position.x, 0.0f, blueTank.position.z);
        Debug.Log(targetXZPos);
        Debug.Log("((//((/(()");
        arrel = (Mathf.Sqrt((Mathf.Pow(velocity.magnitude, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(blueTank.position.z, 2)) + (2 * blueTank.position.y * Mathf.Pow(velocity.magnitude, 2)))))));
        Debug.Log("Arrel");
        Debug.Log(arrel);
        if (arrel < 0)
        {
            arrel = -arrel;
            angle = (Mathf.Pow(velocity.magnitude, 2) + arrel) / (Physics.gravity.y * blueTank.position.z);
            Debug.Log("a");
        }
        else
        {
            angle = (Mathf.Pow(velocity.magnitude, 2) + arrel) / (Physics.gravity.y * blueTank.position.z);
            Debug.Log("b");
        }
        Debug.Log("Angle");
        Debug.Log(angle);
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(angle * Mathf.Rad2Deg);
        float H = blueTank.position.y - RedTankSpawnBullets.instace.spawnPositionRed.transform.position.y;

        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - (R * tanAlpha))));
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        rb.velocity = globalVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if()
    }
}