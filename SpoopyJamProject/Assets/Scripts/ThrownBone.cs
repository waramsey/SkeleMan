using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownBone : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Debug.Log(hitInfo.name);

        /*
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        */
        Destroy(gameObject);
    }
}
