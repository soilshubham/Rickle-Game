using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_boxspawner : MonoBehaviour
{

    public GameObject prefab;

    public void spawnBox()
    {
        GameObject boxobj = Instantiate(prefab);
        Vector3 temp = transform.position;
        temp.z = 0f;
        boxobj.transform.position = temp;
    }
}
