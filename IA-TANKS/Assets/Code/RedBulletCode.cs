using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private float velocity;
    private Transform blueTank;
    private Vector2 updateVector;
    private float arrel;
    private Vector3 targetXZPos;
    private float distance;
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
        Vector3 projectileXZPos = new Vector3(RedTankSpawnBullets.instace.spawnPositionRed.transform.position.x, transform.position.y, RedTankSpawnBullets.instace.spawnPositionRed.transform.position.z);
        Vector3 dirVec = blueTank.position - transform.position;
        targetXZPos = new Vector3(blueTank.position.x, transform.position.y, blueTank.position.z);
        float  distance2 = blueTank.position.z - transform.position.z;
        Debug.Log(targetXZPos);
        velocity = 50f;
        Debug.Log("((//((/(()");
        arrel = Mathf.Sqrt((Mathf.Pow(velocity, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(blueTank.position.z, 2)) + (2 * blueTank.position.y * Mathf.Pow(velocity, 2))))));
        Debug.Log("Arrel");
        Debug.Log(arrel);
        if (arrel < 0)
        {
            arrel = -arrel;
            angle = Mathf.Atan((Mathf.Pow(velocity, 2) + arrel) / (Physics.gravity.y * blueTank.position.z));
            Debug.Log("a");
        }
        else
        {
            angle = Mathf.Atan((Mathf.Pow(velocity, 2) + arrel) / (Physics.gravity.y * blueTank.position.z));
            Debug.Log("b");
        }
        //float theta = 0.5f * Mathf.Asin((gravity * distance) / (projectileSpeed * projectileSpeed));
        angle = 0.5f * Mathf.Asin((Physics.gravity.y * distance2) / (velocity * velocity));
        Debug.Log("Angle");
        Debug.Log(angle);
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = (angle * Mathf.Deg2Rad);
        float H = blueTank.position.y - RedTankSpawnBullets.instace.spawnPositionRed.transform.position.y;
        Vector3 releaseVector = (Quaternion.AngleAxis(tanAlpha, -Vector3.forward) * dirVec).normalized;
        float Vz = Mathf.Sqrt((G * R * R) / (2.0f * (H - (R * tanAlpha))));
        float Vy = tanAlpha * Vz;



        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        rb.velocity = releaseVector*asda.instance.v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if()
    }
}