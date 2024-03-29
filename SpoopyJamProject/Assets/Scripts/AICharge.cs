﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharge : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float sightRadius;
    public bool Spotted;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Spotted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.GetComponent<PlayerMovementScript>().Crouch)
        {
            if (target.position.x - transform.position.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Mathf.Abs(target.position.x - transform.position.x) < sightRadius)
            {
                animator.SetBool("Spotted", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                animator.SetBool("Spotted", false);
            }
        }
        else
        {
            animator.SetBool("Spotted", false);
        }
    }
}
