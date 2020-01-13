using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{

    public GameObject screenCredits;
    //public GameObject back;
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        screenCredits.SetActive(false);
        menu.SetActive(true);
        
    }

    public void creditOpen()
    {
        screenCredits.SetActive(true);
        menu.SetActive(false);

    }
    public void creditClose()
    {

        screenCredits.SetActive(false);
        menu.SetActive(true);

    }

    public void insta()
    {
        Application.OpenURL("https://www.instagram.com/soilshubham/");
    }

    public void twitter()
    {
        Application.OpenURL("https://twitter.com/soilshubham");
    }

    void Update()
    {
        
    }
}
