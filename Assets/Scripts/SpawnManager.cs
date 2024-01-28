using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public Vector2 lowerLimit = new Vector2(-8.7f, 0);
    public Vector2 highertLimit = new Vector2(8.7f, 0);

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
            // SpawnObject();
    }

    public void SpawnObject()
    {
        float randomX = Random.Range(lowerLimit.x, highertLimit.x);
        float randomY = Random.Range(lowerLimit.y, highertLimit.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(objectPrefab, spawnPosition, objectPrefab.transform.rotation);
    }
}
