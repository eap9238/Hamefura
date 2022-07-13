using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharacterAnimator : MonoBehaviour
{
    private IAstarAI ai;
    private Animator animator;
    private SpriteRenderer sprite;

    private int direction = 0;
    private float maxSpeed = 10.0f;
    private float minSpeed = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<IAstarAI>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    int CheckDirection( Vector2 velocity)
    {
        int direction;

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

        return direction;
    }

    void AnimateCharacter(Vector2 velocity)
    {
        string actionName = "";

        if (true) // check if difference in velocity magnitude falls into skid zone? don't know. 
        {
            if (velocity.magnitude < minSpeed)
            {
                actionName = "Stand";
            }
            else
            {
                actionName = "Run"; //Later skid?
                direction = CheckDirection(velocity);
            }
        }

        actionName += "_" + direction;

        animator.Play(actionName);
        sprite.flipX = (direction > 4); // Only use if you mirror
        //animator.speed = velocity.magnitude / maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateCharacter(ai.velocity);
    }
}
