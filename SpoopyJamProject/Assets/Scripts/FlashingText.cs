using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FlashingText : MonoBehaviour
{
    public int toggleInterval;
    public float toggleCount;
    public bool toggled;
    public Text text;
    public int counter = 3;
    public int afk = 15;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.color = Color.white;
        toggled = false;
    }

    // Update is called once per frame
    void Update()
    {
        toggleCount += Time.deltaTime;
        if (toggleCount > toggleInterval)
        {
            if (toggled)
            {
                text.color = Color.white;
            }
            else
            {
                text.color = Color.black;
            }
            toggleCount = 0.0f;
            toggled = !toggled;
        }

        if (Input.anyKey && Time.timeSinceLevelLoad > counter)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (Time.timeSinceLevelLoad > afk)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }
}
