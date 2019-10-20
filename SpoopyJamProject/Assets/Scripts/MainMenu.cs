using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int counter = 3;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && Time.timeSinceLevelLoad > counter)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }
}
