using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharacterController2D : MonoBehaviour
{
    IAstarAI ai;

    private Vector2 acceleration;
    private Vector2 velocity;
    private bool moveKey;
    private int direction = 4;

    public float maxSpeed = 10f;
    public float minSpeed = .01f;
    public float traction = .975f;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        acceleration = new Vector2(x, y);
        moveKey = acceleration.magnitude > 0;
        
        velocity *= traction;
        velocity += acceleration;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        if (velocity.magnitude < minSpeed && velocity.magnitude > 0)
        {
            velocity = new Vector2();
        }

        transform.position += (Vector3)velocity * Time.deltaTime;
    }


}
