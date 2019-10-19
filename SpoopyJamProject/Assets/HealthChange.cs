using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthChange : MonoBehaviour
{
    public int HP;
    public Sprite sprite1;
    public Sprite sprite2;
    public GameObject[] hearts;


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
        HP--;
        hearts[HP].GetComponent<Image>().sprite = sprite2;
    }
}
