using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie5 : MonoBehaviour
{
    public GameObject cubePrefab;
    public int numberOfObjectsToSpawn = 10;
    public Vector3 spawnArea = new Vector3(10, 0, 10);

    void Start()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), 0, Random.Range(-spawnArea.z / 2, spawnArea.z / 2));
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }
}
