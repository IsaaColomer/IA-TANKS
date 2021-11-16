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
        float targetX = (blueTank.position.x-transform.position.x);
        float targetZ = (blueTank.position.z-transform.position.z);
        float targetY = (blueTank.position.y-transform.position.y);

        float distance = Vector3.Distance(blueTank.position, transform.position);

        float xAng = Mathf.Sqrt(Mathf.Pow(targetX, 2) + Mathf.Pow(targetZ, 2));

        float square = (Mathf.Pow(asda.instance.v, 4)) - (Physics.gravity.y * (Physics.gravity.y * (Mathf.Pow(targetX, 2) + 2 * targetY * Mathf.Pow(asda.instance.v, 2))));

        if(square<0)
        {
            Debug.Log("Not enough range");
        }

        angle = ((Mathf.Pow(asda.instance.v, 2)) - (Mathf.Sqrt(square) / (Physics.gravity.y * targetX)));

        float finalAngle = Mathf.Tan(angle * Mathf.Deg2Rad);

        float Vz = Mathf.Sqrt(Physics.gravity.y *(Mathf.Pow(distance,2)) / (2.0f * (targetY - (distance * finalAngle))));
        float Vy = finalAngle * Vz;

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        // launch the object by setting its initial velocity and flipping its state
        rb.velocity = globalVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if()
    }
}