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
        velocity =  15f;
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
        Vector3 projectileXZPos = new Vector3(firePoint.transform.position.x, 0.0f, firePoint.transform.position.z);
        Vector2 targetXZPos = new Vector2(targetX, targetZ);
        float distance = Vector3.Distance(blueTank2, transform.position);

        //float xAng = Mathf.Sqrt(Mathf.Pow(targetX, 2) + Mathf.Pow(targetZ, 2));

        float square =Mathf.Abs(Mathf.Pow(velocity, 4) - (Physics.gravity.y * (Physics.gravity.y * (Mathf.Pow(Mathf.Abs(targetXZPos.magnitude), 2)) + (2 * targetY * Mathf.Pow(velocity, 2)))));

        angle = (Mathf.Pow(velocity, 2) + Mathf.Sqrt(square)) / (Physics.gravity.y * Mathf.Abs(targetXZPos.magnitude));

        //Debug.Log(angle);

        float finalAngle = Mathf.Atan(Mathf.Abs(angle));
        //Debug.Log(finalAngle*Mathf.Rad2Deg);

        // calculate the local space components of the velocity 
        // required to land the projectile on the target object 
        float Vz = velocity * Mathf.Sin(finalAngle);
        float Vy = velocity * Mathf.Cos(finalAngle);

        localVelocity = new Vector3(0f, Vy, Vz);

        localVelocity = transform.TransformDirection(localVelocity);
        //Debug.Log("Local velocity: " + localVelocity.magnitude);
        rb.AddForce(localVelocity, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Blue")
        {
            GameObject.Find("Time").GetComponent<TimeDelta>().blueLife -= 10;
            Debug.Log(GameObject.Find("Time").GetComponent<TimeDelta>().blueLife);
        }
    }
}