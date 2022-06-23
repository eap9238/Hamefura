using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Vector2 acceleration;
    private Vector2 velocity;
    private bool moveKey;
    private int direction = 4;

    public float maxSpeed = 10f;
    public float minSpeed = .01f;
    public float traction = .975f;

    public Animator animator;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2();
    }

    void CheckDirection()
    {
        float angle = Vector2.Dot(velocity.normalized, Vector2.up);

        if (angle > .75)
        {
            direction = 0;
        }
        else if (angle > .25)
        {
            direction = 1;
        }
        else if (angle > -.25)
        {
            direction = 2;
        }
        else if (angle > -.75)
        {
            direction = 3;
        }
        else
        {
            direction = 4;
        }
        
        if (velocity.x > 0f)
        {
            direction = (8 - direction) % 8;
        }
    }

    void AnimateCharacter()
    {
        string actionName = "";

        if (!moveKey)
        {
            if (velocity.magnitude < minSpeed)
            {
                actionName = "Stand";
            }
            else
            {
                actionName = "Run"; //Later skid?
            }
        }
        else
        {
            actionName = "Run";
            CheckDirection();
        }

        actionName += "_" + direction;

        animator.Play(actionName);
        sprite.flipX = (direction > 4); // Only use if you mirror
        animator.speed = velocity.magnitude / maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = new Vector2();
        moveKey = false;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            acceleration += new Vector2(0, 1);
            moveKey = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            acceleration += new Vector2(-1, 0);
            moveKey = true;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            acceleration += new Vector2(0, -1);
            moveKey = true;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            acceleration += new Vector2(1, 0);
            moveKey = true;
        }

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
        AnimateCharacter();
    }


}
