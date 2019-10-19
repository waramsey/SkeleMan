using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bonePrefab;
    public float fireRate = 1f;
    private float lastShot = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("enter"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > fireRate + lastShot)
        {
            Instantiate(bonePrefab, firePoint.position, firePoint.rotation);
            lastShot = Time.time;
        }
    }
}
