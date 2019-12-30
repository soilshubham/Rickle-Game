using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class new_boxScript : MonoBehaviour
{
    private float minX = -2.2f, maxX = 2.2f;
    private bool canMove;
    public float moveSpeed;

    private Rigidbody2D mybody;


    private bool ignoreCollison;
    public static bool ignoreTrigger;
    private bool gameOver = false;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        mybody.gravityScale = 0;
    }

    void Start()
    {
        canMove = true;

        if (Random.Range(0, 2) > 0)
        {
            moveSpeed *= -1f;
        }

        new_gameplaycontroller.instance.currentbox = this;

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


            if (temp.x > maxX)
            {
                moveSpeed *= -1;
            }
            else if (temp.x < minX)
            {
                moveSpeed *= -1;
            }
            transform.position = temp;
        }
    }

    public void dropBox()
    {
        canMove = false;
        mybody.gravityScale = Random.Range(2, 4);

    }

    public void landed()
    {

        if (gameOver)
        {
            return;
        }

        ignoreTrigger = true;
        ignoreCollison = true;
        new_gameplaycontroller.instance.spawnnewBox();
        new_gameplaycontroller.instance.moveCamera();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("NNNNNNNNNNNNOOOOOOOOOOOOOOOOOOOO");
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollison)
        {
            return;
        }

        if(target.gameObject.tag == "Platform")
        {
            Invoke("landed", 2f);
            ignoreCollison = true;
        }
        if (target.gameObject.tag == "Box")
        {
            Invoke("landed", 2f);
            ignoreCollison = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
        {
            return;
        }

        if(target.tag == "gameover")
        {
            CancelInvoke("landed");
            gameOver = true;
            ignoreTrigger = true;

            Invoke("restartGame", 2f);
        }
    }

}
