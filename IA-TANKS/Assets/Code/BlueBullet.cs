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
        float targetX = (redTank.position.x - transform.position.x);
        float targetZ = (redTank.position.z - transform.position.z);
        float targetY = (redTank.position.y - transform.position.y);

        float distance = Vector3.Distance(redTank.position, transform.position);

        float xAng = Mathf.Sqrt(Mathf.Pow(targetX, 2) + Mathf.Pow(targetZ, 2));

        float square = (Mathf.Pow(asda.instance.v, 4)) - (Physics.gravity.y * (Physics.gravity.y * (Mathf.Pow(targetX, 2) + 2 * targetY * Mathf.Pow(asda.instance.v, 2))));

        if (square < 0)
        {
            Debug.Log("Not enough range");
            square = -square;
        }

        angle = ((Mathf.Pow(asda.instance.v, 2)) + (Mathf.Sqrt(square) / (Physics.gravity.y * targetX)));

       // rb.velocity =( angle * asda.instance.v)*transform.


       //Debug.Log(angle);
        float finalAngle = (angle * Mathf.Rad2Deg);
    }
}