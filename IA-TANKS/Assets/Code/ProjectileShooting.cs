using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.

public class ProjectileShooting : MonoBehaviour
{
    public Transform enemy;
    private Transform firePoint;
    private Vector2 acceleration;
    private Vector2 velocity;
    private Vector2 initialVelocity;
    [SerializeField]private float gravity;
    [SerializeField] private float angle;
    // Start is called before the first frame update
    void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        gravity = -9.8f;
        velocity = Vector2.zero;
        initialVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        acceleration.x = 0;
        acceleration.y = gravity;
    }
    void CalculateVelocity()
    {
        velocity.x = initialVelocity.x * Mathf.Cos(angle);
        velocity.y = ((initialVelocity.y * Mathf.Sin(angle))-gravity*Time.deltaTime);
    }
}
