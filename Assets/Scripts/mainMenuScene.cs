using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainMenuScene : MonoBehaviour
{

    public void mainMenuChange()
    {
        SceneManager.LoadScene("Menu");
    }
}
