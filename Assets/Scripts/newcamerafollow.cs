using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newcamerafollow : MonoBehaviour
{

    public Vector3 targetPos;
    public float smoothMove = 2f;

    private void Start()
    {
        targetPos = transform.position;
    }
    void update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothMove * Time.deltaTime);
    }

}
