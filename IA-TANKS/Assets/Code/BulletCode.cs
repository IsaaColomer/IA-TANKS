using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    private float angle;
    [SerializeField]private float time;
    private float gravity;
    private Vector2 initialVelocity = new Vector2(100f,100f);
    private Vector2 velocity;
    private Vector2 startVector;
    private Vector2 updateVector;
    private float arrel;
    // Start is called before the first frame update
    void Start()
    {
        gravity = -30f;
        startVector = ProjectileShooting.instace.enemy.transform.position - ProjectileShooting.instace.spawnPosition.transform.position;
        arrel = 0;
        arrel = (Mathf.Sqrt((Mathf.Pow(ProjectileShooting.instace.v, 4) - (gravity * ((gravity * Mathf.Pow(ProjectileShooting.instace.enemy.transform.position.z, 2)) + (2 * ProjectileShooting.instace.enemy.transform.position.y * Mathf.Pow(ProjectileShooting.instace.v, 2)))))));
        Debug.Log("Arrel");
        Debug.Log(arrel);
        if(arrel < 0)
        {
            arrel = -arrel;
            angle = Mathf.Atan((Mathf.Pow(ProjectileShooting.instace.v, 2) + arrel) / (gravity * ProjectileShooting.instace.enemy.transform.position.z));
        }
        else
        {
            angle = Mathf.Atan((Mathf.Pow(ProjectileShooting.instace.v, 2) + arrel) / (gravity * ProjectileShooting.instace.enemy.transform.position.z));
        }
        
        //angle = (1 / 2) * Mathf.Asin((gravity * startVector.magnitude) / Mathf.Pow(initialVelocity.magnitude, 2));
        Debug.Log("Initial Angle");        
        Debug.Log(angle);        
        time = 0;
        transform.LookAt(ProjectileShooting.instace.enemy.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        velocity.x = (ProjectileShooting.instace.v * time* Mathf.Cos(angle));
        velocity.y = ((ProjectileShooting.instace.v * time  * Mathf.Sin(angle)) - (gravity * time));

        updateVector.x = ((ProjectileShooting.instace.v * time * (Mathf.Cos(angle))));
        updateVector.y = ((ProjectileShooting.instace.v * time * Mathf.Sin(angle)) - ((1 / 2) * gravity * Mathf.Pow(time, 2)));

        transform.position = new Vector3(transform.position.x, updateVector.y, updateVector.x);

        if(time >10f)
        {
           //Destroy(this.gameObject);
        }
    }
    //void FixedUpdate()
    //{
    //    time += Time.deltaTime;
    //    velocity.x = initialVelocity.magnitude * time * Mathf.Cos(angle);
    //    velocity.y = (initialVelocity.magnitude * time * Mathf.Sin(angle))-(gravity*time);

    //    updateVector.x = (initialVelocity.magnitude * time * Mathf.Cos(angle));
    //    updateVector.y = (initialVelocity.magnitude * time * Mathf.Sin(angle))-((1/2)*gravity*Mathf.Pow(time,2));

    //    transform.position = new Vector3(ProjectileShooting.instace.spawnPosition.transform.position.x, updateVector.y, updateVector.x);
    //}
}
