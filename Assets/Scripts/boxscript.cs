using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxscript : MonoBehaviour
{
    public float minX = -2, maxX = 2;
    private bool canMove;
    public static float moveSpeed;

    private Rigidbody2D mybody;

    public static bool death = false;
    public  static bool Trigger;
    private bool gameOver;




    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        mybody.gravityScale = 0;
        Trigger = true;
        death = false;

    }
    void Start()
    {
        canMove = true;

        if(Random.Range(0,2) > 0)
        {
            moveSpeed *= -1;
        }

        gameplayController.instance.currentbox = this;
    }

    void Update()
    {
        moveBox();

    }

    void moveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (transform.position.x >= maxX)
            {
                moveSpeed *= -1;
            }
            else if (transform.position.x <= minX)
            {
                moveSpeed *= -1;
            }
        }
    }

    public void dropBox()
    {
        canMove = false;
        mybody.gravityScale = Random.Range(2, 4);        

    }

    public void landed()
    {
        gameplayController.instance.spawnnewBox();

        Trigger = false;
        gameplayController.instance.score += 1;
        this.tag = "landed";

    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Box" && Trigger)
        {
            //landed();
        }
        if (target.tag == "landed" && Trigger)
        {
            landed();
        }
        if (target.tag == "Platform" && Trigger)
        {
            landed();


        }
        if (target.tag == "gameover")
        {


            CancelInvoke("landed");
            Trigger = true;

            //gameplayController.pauseMenu.SetActive(true);

            gameplayController.menuOpen = true;

            moving.canMove = false;

            gameplayController.instance.disableCubes();



        }


    }

}
