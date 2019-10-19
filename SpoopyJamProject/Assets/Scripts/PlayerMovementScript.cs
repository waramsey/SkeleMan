using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
	public Vector2 sidewaysForce;

	void start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d"))
		{
			rb.velocity = new Vector2(2, GetComponent<Rigidbody2D>().velocity.y);
		}

		if (Input.GetKey("a"))
		{
			rb.velocity = new Vector2(-2, GetComponent<Rigidbody2D>().velocity.y);
		}
    }
}