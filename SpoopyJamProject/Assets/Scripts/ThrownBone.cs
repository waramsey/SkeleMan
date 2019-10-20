using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBone : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject[] enemies;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");

        //Instantiate(impactEffect, transform.position, transform.rotation);
        if (hitInfo.tag == "Enemy")
        {
            GameObject enemy = hitInfo.gameObject;

            Destroy(enemy);
        }

        if (hitInfo.name != "BoneBoi")
        {
            Destroy(gameObject);
        }


    }
}
