using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCharacter : MonoBehaviour
{
    public Sprite[] spriteList;

    public bool mirror;

    private SpriteRenderer spriteRenderer;

    private int totalsteps;
    private int currentStep = 0;

    private float timer = 0.125f;
    private float timeElapsed = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (mirror)
        {
            totalsteps = spriteList.Length * 2 - 2;
        }
        else
        {
            totalsteps = spriteList.Length;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timer)
        {
            timeElapsed -= timer;

            currentStep++;

            if (currentStep >= totalsteps)
            {
                currentStep = 0;
            }

            if (mirror && currentStep >= spriteList.Length)
            {
                spriteRenderer.sprite = spriteList[totalsteps - currentStep];

                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.sprite = spriteList[currentStep];

                spriteRenderer.flipX = false;
            }
        }
    }
}
