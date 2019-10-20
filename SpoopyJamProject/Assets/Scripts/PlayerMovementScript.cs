using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject[] ground;
    public float speed;
    public float jumpHeight;
    public bool Crouch;

	void start()
	{
        speed = 3;
        jumpHeight = 8;
        Crouch = false;
		rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (Input.GetKey("s"))
        {
            animator.SetBool("Crouch", true);
        }

        else
        {
            animator.SetBool("Crouch", false);
            if (Input.GetKey("space"))
            {
                ground = GameObject.FindGameObjectsWithTag("ground"); //Might cause problems refilling array later
                for (int i = 0; i < ground.Length; i++)
                {
                    if (GetComponent<BoxCollider2D>().IsTouching(ground[i].GetComponent<BoxCollider2D>()))
                    {
                        rb.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                    }
                }
            }

            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }

            if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}