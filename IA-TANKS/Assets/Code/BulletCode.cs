using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField]private float time;
    private Rigidbody rb;
    private Vector2 velocity;
    private Vector2 updateVector;
    private float arrel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        arrel = 0;
        arrel = (Mathf.Sqrt((Mathf.Pow(ProjectileShooting.instace.v, 4) - (Physics.gravity.y * ((Physics.gravity.y * Mathf.Pow(ProjectileShooting.instace.enemy.transform.position.z, 2)) + (2 * ProjectileShooting.instace.enemy.transform.position.y * Mathf.Pow(ProjectileShooting.instace.v, 2)))))));
        if(arrel < 0)
        {
            arrel = -arrel;
            angle = Mathf.Atan((Mathf.Pow(ProjectileShooting.instace.v, 2) + arrel) / (Physics.gravity.y * ProjectileShooting.instace.enemy.transform.position.z));
        }
        else
        {
            angle = Mathf.Atan((Mathf.Pow(ProjectileShooting.instace.v, 2) + arrel) / (Physics.gravity.y * ProjectileShooting.instace.enemy.transform.position.z));
        }        
        time = 0;
        transform.LookAt(ProjectileShooting.instace.enemy.transform.position);
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.LookAt(ProjectileShooting.instace.enemy.transform.position);
    }
    void Launch()
    {
        Vector3 projectileXZPos = new Vector3(ProjectileShooting.instace.spawnPosition.transform.position.x, 0.0f, ProjectileShooting.instace.spawnPosition.transform.position.z);
        Vector3 targetXZPos = new Vector3(ProjectileShooting.instace.enemy.transform.position.x, 0.0f, ProjectileShooting.instace.enemy.transform.position.z);

        float R = Vector3.Distance(projectileXZPos, targetXZPos);
        float G = Physics.gravity.y;
        angle = 45;
        float tanAlpha = Mathf.Tan(angle * Mathf.Deg2Rad);
        float H = ProjectileShooting.instace.enemy.transform.position.y - ProjectileShooting.instace.spawnPosition.transform.position.y;

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
