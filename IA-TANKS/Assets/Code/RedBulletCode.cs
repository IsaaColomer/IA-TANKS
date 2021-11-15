using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private Vector2 velocity = new Vector2(0.0f, 0.0f);
    private Transform blueTank;
    private Vector2 updateVector;
    private float arrel;
    private Vector3 targetXZPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        blueTank = GameObject.FindGameObjectWithTag("Blue").transform;
        arrel = (Mathf.Sqrt((Mathf.Pow(velocity.magnitude, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(blueTank.transform.position.z, 2)) + (2 * blueTank.transform.position.y * Mathf.Pow(velocity.magnitude, 2)))))));
        if (arrel < 0)
        {
            arrel = -arrel;
            angle = Mathf.Atan((Mathf.Pow(velocity.magnitude, 2) + arrel) / (Physics.gravity.y * blueTank.transform.position.z));
        }
        else
        {
            angle = Mathf.Atan((Mathf.Pow(velocity.magnitude, 2) + arrel) / (Physics.gravity.y * blueTank.transform.position.z));
        }
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

        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        angle = 45;
        float tanAlpha = Mathf.Tan(angle * Mathf.Deg2Rad);
        float H = blueTank.transform.position.y - RedTankSpawnBullets.instace.spawnPositionRed.transform.position.y;

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