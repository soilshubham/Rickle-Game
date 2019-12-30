using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float movespeed = 2f;
    public Vector3 targetPos;

    private void Start()
    {
        targetPos = transform.position;
    }
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, movespeed * Time.deltaTime);
    }
    public void move()
    {
/*        Vector3 temp = this.transform.position;
        temp.y += 2f;*/
        //Vector3.Lerp(transform.position, temp, movespeed * Time.deltaTime);


    }

}
