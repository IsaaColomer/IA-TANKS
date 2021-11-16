using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBullet : MonoBehaviour
{
    private float angle;
    [SerializeField] private float time;
    private Rigidbody rb;
    private float velocity;
    private Transform redTank;
    private Vector2 updateVector;
    private float arrel;
    private Vector3 targetXZPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        redTank = GameObject.FindGameObjectWithTag("Red").transform;

        time = 0;
        transform.LookAt(BlueTankBullet.instace.enemy.transform.position);
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.LookAt(BlueTankBullet.instace.enemy.transform.position);
    }
    void Launch()
    {
        Vector3 projectileXZPos = new Vector3(BlueTankBullet.instace.spawnPositionBlue.transform.position.x, 0.0f, BlueTankBullet.instace.spawnPositionBlue.transform.position.z);
        targetXZPos = new Vector3(redTank.position.x, 0.0f, redTank.position.z);
        velocity = 50f;
        arrel = (Mathf.Sqrt((Mathf.Pow(velocity, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(redTank.position.z, 2)) + (2 * redTank.position.y * Mathf.Pow(velocity, 2)))))));
        if (arrel < 0)
        {
            arrel = -arrel;
            angle = Mathf.Atan((Mathf.Pow(velocity, 2) + arrel) / (Physics.gravity.y * redTank.position.z));
        }
        else
        {
            angle = Mathf.Atan((Mathf.Pow(velocity, 2) + arrel) / (Physics.gravity.y * redTank.position.z));
        }
        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        
        float tanAlpha = Mathf.Tan(angle * Mathf.Rad2Deg);
        float H = redTank.position.y - BlueTankBullet.instace.spawnPositionBlue.transform.position.y;

        float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - (R * tanAlpha))));
        float Vy = tanAlpha * Vz;

        Vector3 localVelocity = new Vector3(0f, Vy, Vz);
        Vector3 globalVelocity = transform.TransformDirection(localVelocity);

        rb.velocity = globalVelocity;
    }
}