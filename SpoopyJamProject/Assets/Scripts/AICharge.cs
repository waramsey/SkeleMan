using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharge : MonoBehaviour
{
    public float speed;
    private Transform target;
    public float sightRadius;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x - transform.position.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Mathf.Abs(target.position.x - transform.position.x) < sightRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
