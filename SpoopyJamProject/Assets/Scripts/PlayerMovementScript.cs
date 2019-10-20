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

	void start()
	{
        speed = 3;
        jumpHeight = 8;
		rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

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
		}

		if (Input.GetKey("a"))
		{
			rb.velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
		}
    }
}