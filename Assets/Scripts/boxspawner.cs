using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxspawner : MonoBehaviour
{
    public GameObject boxPrefab;

    public GameObject cubeParents;
    public bool randomSpawn = true;
    public int count = 0;
    private void Start()
    {

    }
    public void spawnBox()
    {
        GameObject boxObject = Instantiate(boxPrefab);
        boxObject.transform.SetParent(cubeParents.transform);
        Vector3 temp = transform.position;
        temp.z = 0f;
        temp.x = Random.Range(-1, 1);
        boxObject.transform.position = temp;
    }
}
