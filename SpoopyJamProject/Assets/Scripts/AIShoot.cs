using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Transform firePoint;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public float fireRate = 1f;
    private float lastShot = 0.0f;
    public float sightRadius;
    public float tooClose;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        animator.SetBool("Spotted", false);
        animator.SetBool("TooClose", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < tooClose)
        {
            animator.SetBool("TooClose", true);
            animator.SetBool("Spotted", true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, -(speed * Time.deltaTime));
            if (target.position.x - transform.position.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (Mathf.Abs(target.position.x - transform.position.x) < sightRadius && Mathf.Abs(target.position.y - transform.position.y) < 10)
        {
            animator.SetBool("TooClose", false);
            animator.SetBool("Spotted", true);
            if (target.position.x - transform.position.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            Shoot();
        }
        else
        {
            animator.SetBool("Spotted", false);
            animator.SetBool("TooClose", false);
        }
    }


    void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
            if (!GetComponent<SpriteRenderer>().flipX)
            {
                //firePoint.transform.position = new Vector3(-1.3f, 0, 0);
                //firePoint.position.Set(-1.3f, 0, 0); //change firepoint

                Instantiate(arrowLeft, firePoint.position, firePoint.rotation);
                arrowLeft.GetComponent<Transform>().transform.Rotate(0, 0, 315);
                lastShot = Time.time;
                
            } else
            {
                //firePoint.transform.position = new Vector3(1.3f, 0, 0);

                Instantiate(arrowRight, firePoint.position, firePoint.rotation);
                arrowRight.GetComponent<Transform>().transform.Rotate(0, 0, 315);
                lastShot = Time.time;
            }
        }
    }
}
