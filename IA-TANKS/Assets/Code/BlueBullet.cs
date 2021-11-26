using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private float velocity;
    [SerializeField] private Transform blueTank;
    [SerializeField] private Vector3 blueTank2;
    [SerializeField] private Transform firePoint;
    private Vector2 updateVector;
    private float arrel;
    private Vector3 targetXZPos;
    private float distance;
    Vector3 localVelocity;
    [SerializeField] private Vector3 startpos;
    Vector3 globalVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        blueTank = GameObject.FindGameObjectWithTag("RedFirePoint").transform;
        blueTank2 = transform.TransformDirection(blueTank.transform.position);
        firePoint = GameObject.FindGameObjectWithTag("BlueFirePoint").transform;
        velocity = 10f;
        time = 0;
        transform.LookAt(blueTank.transform.position);
        startpos = transform.position;
        transform.position = firePoint.position;
        Launch();
        transform.LookAt(blueTank);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
    void Launch()
    {
        velocity = 10;
        float targetX = (blueTank2.x - transform.position.x);
        float targetZ = (blueTank2.z - transform.position.z);
        float targetY = (blueTank2.y - transform.position.y);
        Vector2 targetXZPos = new Vector2(targetX, targetZ);


        float square = Mathf.Abs(Mathf.Pow(velocity, 4) - (Physics.gravity.y * (Physics.gravity.y * (Mathf.Pow(Mathf.Abs(targetXZPos.magnitude), 2)) + (2 * targetY * Mathf.Pow(velocity, 2)))));

        angle = (Mathf.Pow(velocity, 2) + Mathf.Sqrt(square)) / (Physics.gravity.y * Mathf.Abs(targetXZPos.magnitude));


        float finalAngle = Mathf.Atan(Mathf.Abs(angle));

        float Vz = velocity * Mathf.Sin(finalAngle);
        float Vy = velocity * Mathf.Cos(finalAngle);

        localVelocity = new Vector3(0f, Vy, Vz);
        localVelocity = transform.TransformDirection(localVelocity);

        rb.AddForce(localVelocity, ForceMode.Impulse);
    }
}