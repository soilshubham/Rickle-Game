using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public float moveSpeed;
    private float maxX = 2.2f, minX = -2.2f;
    private Rigidbody2D rb;

    public static bool canMove;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) {
        Vector3 temp = transform.position;
            temp.x += moveSpeed * Time.deltaTime;
            transform.position = temp;

            if (transform.position.x > maxX)
            {
                moveSpeed *= -1;
            }
            else if (transform.position.x < minX)
            {
                moveSpeed *= -1;
            }
        }
    }
}
