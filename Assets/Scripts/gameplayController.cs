using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class gameplayController : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject RealPauseMenu;
    public static bool menuOpen;
    public static bool pauseMenuOpen;

    public static gameplayController instance;
    public boxspawner box_spawner;
    [HideInInspector]
    public boxscript currentbox;
    public float currentLevelSpeed;

    public GameObject cubeParentToDelete;

    public Text scoreText = null;
    public Text lastScore = null;

    public cameraFollow cameraScript;
    public int moveCount = 1;
    public int score = 0;

    public static bool audioMute;
    public AudioSource backgroundMusic;

    private float lowPassValue;


    public GameObject pauseButton;


    public void Awake()
    {
        pauseButton.SetActive(true);
        score = 0;
        if(instance == null)
        {
            instance = this;
        }

        boxscript.moveSpeed = currentLevelSpeed;

        pauseMenu.SetActive(false);
        RealPauseMenu.SetActive(false);
        pauseMenuOpen = false;
    }
    void Start()
    {
        box_spawner.spawnBox();
        menuOpen = false;
        lowPassValue = GetComponent<AudioLowPassFilter>().cutoffFrequency;
        lowPassValue = 22000;
        if (audioMute)
        {
            backgroundMusic.mute = !backgroundMusic.mute;
        }



    }

    void Update()
    {
        GetComponent<AudioLowPassFilter>().cutoffFrequency = lowPassValue;

        if (boxscript.death)
        {
            pauseButton.SetActive(false);
        }


        if (pauseMenuOpen)
        {
            if (lowPassValue > 1000)
            {
                lowPassValue -= 1000;
            }
        }
        else
        {
            if (boxscript.death)
            {
                if (lowPassValue > 1000)
                {
                    lowPassValue -= 1000;
                }
            }
            else
            {
                if (lowPassValue < 22000)
                {
                    lowPassValue += 1000;
                }
            }

        }


        detectInput();

        scoreText.text = "S C O R E - " + score;
        lastScore.text = "" + score;




        if (menuOpen)
        {
            pauseMenu.SetActive(true);
            boxscript.death = true;
        }

        if (pauseMenuOpen)
        {

        }

    }

    public void pauseMenuEnable()
    {
        Time.timeScale = 0;
        pauseMenuOpen = true;
        RealPauseMenu.SetActive(true);
    }

    public void continueButton()
    {
        Time.timeScale = 1;
        RealPauseMenu.SetActive(false);
        pauseMenuOpen = false;
    }

    public void disableCubes()
    {
        cubeParentToDelete.SetActive(false);

    }

    void detectInput()
    {
        if (Input.GetMouseButton(0) && !mouseOverUi() && !pauseMenuOpen)
        {
            currentbox.dropBox();
        }
    }

    public bool mouseOverUi()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void spawnnewBox()
    {
        Invoke("newBox",0.4f);
    }

    void newBox()
    {
        box_spawner.spawnBox();



        moveCount++;
        if(moveCount > 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;


        }
        /*        if(moveCount > 1)
                {
                    gameover.SetActive(true);
                }*/
    }




    public void cameraMove()
    {
        cameraScript.move();

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }


}
