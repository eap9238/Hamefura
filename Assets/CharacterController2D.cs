using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Vector3 acceleration;
    private Vector3 velocity;
    public float maxSpeed = 10f;
    public float traction = .975f;

    public Animator animator;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            acceleration += new Vector3(0, 1, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            acceleration += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            acceleration += new Vector3(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            acceleration += new Vector3(1, 0, 0);
        }

        //Cheap animator -- probably wants their own script?
        if (velocity.x < -.1f || velocity.x > .1f)
        {
            animator.Play("Run_H");
            sprite.flipX = (velocity.x > 0f);
        }

        velocity *= traction;
        velocity += acceleration;

        if (velocity.magnitude > maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        if (velocity.magnitude < .01f && velocity.magnitude > 0)
        {
            animator.Play("Stand_H");
            velocity = new Vector3();
        }

        transform.position += velocity * Time.deltaTime;
    }


}
