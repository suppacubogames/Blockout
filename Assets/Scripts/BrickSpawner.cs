using System;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab; // Prefab for the brick to be spawned
    [SerializeField] private float spacing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBricks(); // Call the method to spawn bricks at the start of the game
    }

    void SpawnBricks()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(brickPrefab, new Vector2((i * spacing)-3, 2f), Quaternion.identity); // Spawn a brick at the specified position with no rotation
        }
    }

}
