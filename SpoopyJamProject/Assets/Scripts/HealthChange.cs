﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthChange : MonoBehaviour
{
    public int HP;
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject[] hearts;
    public GameObject[] enemies;
    //public GameObject[] projectiles;


    // Start is called before the first frame update
    void Start()
    {
        HP = 3;

        for (int i = 0; i < 3; i++)
        {
            hearts[i].GetComponent<Image>().sprite = sprite1;
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //Might cause problems refilling array later
        //projectiles = GameObject.FindGameObjectsWithTag("projectile"); // lets just make the problem worse yolo

        if (GetComponent<BoxCollider2D>().IsTouching(GameObject.FindWithTag("Killbox").GetComponent<BoxCollider2D>()))
        {
            HP = 0;
            hearts[0].GetComponent<Image>().sprite = sprite2;
            hearts[1].GetComponent<Image>().sprite = sprite2;
            hearts[2].GetComponent<Image>().sprite = sprite2;
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            if (GetComponent<BoxCollider2D>().IsTouching(enemies[i].GetComponent<BoxCollider2D>()))
            {
                HP--;
                hearts[HP].GetComponent<Image>().sprite = sprite2;
            }
        }

        /*
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (GetComponent<BoxCollider2D>().IsTouching(enemies[i].GetComponent<BoxCollider2D>()))
            {
                HP--;
                hearts[HP].GetComponent<Image>().sprite = sprite2;
            }
        }
        */

        if (GetComponent<BoxCollider2D>().IsTouching(GameObject.FindWithTag("coffin").GetComponent<BoxCollider2D>()))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
