using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{
    public int objectsToGenerate = 10;
    public float delay = 3.0f;
    public GameObject block;
    public Material[] materials;
    public float minDistanceBetweenObjects = 1.0f;
    public float minDistanceFromEdge = 1.0f;

    private List<Vector3> generatedPositions = new List<Vector3>();

    void Start()
    {
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        Debug.Log("Wywołano coroutine");

        Bounds platformBounds = GetComponent<Collider>().bounds;

        for (int i = 0; i < objectsToGenerate; i++)
        {
            Vector3 newPosition = GenerateValidPosition(platformBounds, generatedPositions);
            generatedPositions.Add(newPosition);

            GameObject newBlock = Instantiate(block, newPosition, Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            yield return new WaitForSeconds(delay);
        }
    }

    Vector3 GenerateValidPosition(Bounds bounds, List<Vector3> existingPositions)
    {
        Vector3 position = Vector3.zero;
        do
        {
            float randomX = Random.Range(bounds.min.x + minDistanceFromEdge, bounds.max.x - minDistanceFromEdge);
            float randomZ = Random.Range(bounds.min.z + minDistanceFromEdge, bounds.max.z - minDistanceFromEdge);
            position = new Vector3(randomX, 0.5f, randomZ);
        } while (IsPositionOccupied(position, existingPositions));

        return position;
    }

    bool IsPositionOccupied(Vector3 position, List<Vector3> existingPositions)
    {
        foreach (var existingPos in existingPositions)
        {
            if (Vector3.Distance(position, existingPos) < minDistanceBetweenObjects)
            {
                return true;
            }
        }
        return false;
    }
}
