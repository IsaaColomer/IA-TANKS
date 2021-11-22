using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private float velocity;
    [SerializeField]private Transform blueTank;
    [SerializeField]private Vector3 blueTank2;
    [SerializeField]private Transform firePoint;
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
        blueTank = GameObject.FindGameObjectWithTag("BlueFirePoint").transform;
        blueTank2 = transform.TransformDirection(blueTank.transform.position);
        firePoint = GameObject.FindGameObjectWithTag("RedFirePoint").transform;
        velocity =  10f;
        time = 0;
        transform.LookAt(blueTank.transform.position);
        startpos = transform.position;
        transform.position = firePoint.position;
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.LookAt(blueTank.transform.position);

        Debug.DrawLine(firePoint.transform.position, blueTank2, Color.blue);
    }
    void Launch()
    {
        float targetX = (blueTank2.x - transform.position.x);
        float targetZ = (blueTank2.z - transform.position.z);
        float targetY = (blueTank2.y - transform.position.y);

        float distance = Vector3.Distance(blueTank2, transform.position);

        //float xAng = Mathf.Sqrt(Mathf.Pow(targetX, 2) + Mathf.Pow(targetZ, 2));

        float square =Mathf.Abs(Mathf.Pow(velocity, 4) - (Physics.gravity.y * (Physics.gravity.y * (Mathf.Pow(Mathf.Abs(targetZ), 2)) + (2 * Mathf.Abs(targetY) * Mathf.Pow(velocity, 2)))));

        angle = (Mathf.Pow(velocity, 2) + Mathf.Sqrt(square)) / (Physics.gravity.y * Mathf.Abs(targetZ));

        Debug.Log(angle);

        float finalAngle = (Mathf.Atan(Mathf.Abs(angle)));
        Debug.Log(finalAngle*Mathf.Rad2Deg);

        Vector3 projectileXZPos = new Vector3(firePoint.transform.position.x, 0.0f, firePoint.transform.position.z);
        Vector3 targetXZPos = new Vector3(blueTank2.x, 0.0f, blueTank2.z);

        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        float tanAlpha = Mathf.Tan(Mathf.Abs(finalAngle) * Mathf.Rad2Deg);
        float H = blueTank2.y - firePoint.position.y;

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
        float Vy = tanAlpha * Vz;

        localVelocity = new Vector3(0f, Vy, Vz);

        globalVelocity = transform.TransformDirection(localVelocity);

        rb.velocity = globalVelocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if()
    }
}