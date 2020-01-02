using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HIGHSCORE : MonoBehaviour
{



    public Text nHSDisplay;
    public Text hHSDisplay;
    public Text eHSDisplay;


    public int normalHighscoreValue = 0;
    public int hardHighscoreValue = 0;
    public int epicHighscoreValue = 0;

    void Start()
    {
        normalHighscoreValue = PlayerPrefs.GetInt("nHS");
        hardHighscoreValue = PlayerPrefs.GetInt("hHS");
        epicHighscoreValue = PlayerPrefs.GetInt("eHS");

    }
    void Update()
    {
        if (boxscript.death)
        {
            if (SceneManager.GetActiveScene().name == "normal")
            {
                nHSDisplay.text = "B E S T - " + PlayerPrefs.GetInt("nHS");

            }

            if (SceneManager.GetActiveScene().name == "hard")
            {
                hHSDisplay.text = "B E S T - " + PlayerPrefs.GetInt("hHS");

            }

            if (SceneManager.GetActiveScene().name == "epic")
            {
                eHSDisplay.text = "B E S T - " + PlayerPrefs.GetInt("eHS");

            }

        }





        if (gameplayController.score > normalHighscoreValue && SceneManager.GetActiveScene().name == "normal")
        {
            PlayerPrefs.SetInt("nHS", gameplayController.score);
            nHSDisplay.text = "B E S T - " + PlayerPrefs.GetInt("nHS");

        }


        if (gameplayController.score > hardHighscoreValue && SceneManager.GetActiveScene().name == "hard")
        {
            PlayerPrefs.SetInt("hHS", gameplayController.score);
        }


        if (gameplayController.score > epicHighscoreValue && SceneManager.GetActiveScene().name == "epic")
        {
            PlayerPrefs.SetInt("eHS", gameplayController.score);
            eHSDisplay.text = "B E S T - " + PlayerPrefs.GetInt("eHS");

        }

    }
}
