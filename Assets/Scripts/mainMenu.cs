using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public GameObject diffSelect;
    public GameObject menuSelect;
    public GameObject muteCircle;

    public Text nhsDisplay;
    public Text hhsDisplay;
    public Text ehsDisplay;

    public Animator muteCircleAnim;

    public AudioSource menuMusic;

    private void Start()
    {
        diffSelect.SetActive(false);
        menuSelect.SetActive(true);
        menuMusic.mute = false;

        nhsDisplay.text = "Best: " + PlayerPrefs.GetInt("nHS");
        hhsDisplay.text = "Best: " + PlayerPrefs.GetInt("hHS");
        ehsDisplay.text = "Best: " + PlayerPrefs.GetInt("eHS");

    }


    private void Update()
    {

    }
    public void difficultySelection()
    {
        diffSelect.SetActive(true);
        menuSelect.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void normal()
    {
        SceneManager.LoadScene("normal");
    }
    public void hard()
    {
        SceneManager.LoadScene("hard");
    }
    public void epic()
    {
        SceneManager.LoadScene("epic");
    }

    public void back()
    {
        diffSelect.SetActive(false);
        menuSelect.SetActive(true);
    }

    public void muteAudio()
    {
        gameplayController.audioMute = !gameplayController.audioMute;
        menuMusic.mute = !menuMusic.mute;

        muteCircleAnim.SetBool("audioMute", gameplayController.audioMute);
        muteCircle.SetActive(gameplayController.audioMute);

    }
}
