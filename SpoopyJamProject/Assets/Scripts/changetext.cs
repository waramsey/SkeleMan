using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changetext : MonoBehaviour
{
    public Text mytext = null;
    
    // Update is called once per frame
    void Start()
    {
        mytext.text = "LONG AGO, IN A WORLD OF MAGIC AND FRIGHT...";

        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(5);

        mytext.text = "A TERRIFYING NECROMANCER PLOTTED AGAINST THE LIVING...";

        yield return new WaitForSeconds(5);

        mytext.text = "BUT HIS SKELETON ARMY WOULD NOT BE CONTROLLED!";

        yield return new WaitForSeconds(5);

        mytext.text = "THEY KILLED HIM, AND ONLY SEEK TO REST...";

        yield return new WaitForSeconds(5);

        mytext.text = "BUT IT SEEMS THE LIVING ARE NOT DONE WITH YOU YET...";

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
