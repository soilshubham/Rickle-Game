using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class new_gameplaycontroller : MonoBehaviour
{
    public static new_gameplaycontroller instance;
    public new_boxspawner box_spawner;
    [HideInInspector]
    public new_boxScript currentbox;

    public newcamerafollow cameraScript;
    public int moveCount;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        box_spawner.spawnBox();
    }


    void Update()
    {
        detectInput();

    }

    void detectInput()
    {
        if (Input.GetMouseButton(0))
        {
            currentbox.dropBox();
        }
    }

    public void spawnnewBox()
    {
        Invoke("newBox", 1f);
    }

    void newBox()
    {
        box_spawner.spawnBox();

    }
    public void moveCamera()
    {
        moveCount++;
        if (moveCount == 3)
        {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;

        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("GERE");
    }
}
