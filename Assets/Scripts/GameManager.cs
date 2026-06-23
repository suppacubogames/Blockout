using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BrickSpawner brickSpawner; // Reference to the BrickSpawner script to access the list of bricks
    [SerializeField] private List<GameObject> bricks; // Total number of bricks in the game

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bricks = brickSpawner.GetBricks(); // Get the list of bricks from the BrickSpawner script
    }

    void OnEnable()
    {
        Brick.OnBrickDestroyed += LadrilloDestruido; // Subscribe to the OnBrickDestroyed event to call the LadrilloDestruido method when a brick is destroyed
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LadrilloDestruido()
    {
        bool anyBrickAlive = bricks.Any(brick => brick.activeSelf);

        if(!anyBrickAlive)
        {
            Debug.Log("All bricks destroyed! GREAT SAFE! YOU WIN! INTERNATIONAL SUPER STAR SOCCER DELUXE"); // Log a message to the console when all bricks are deactivated (destroyed). The message is a humorous reference to the game "International Superstar Soccer Deluxe" and is meant to celebrate the player's victory in the game.
        }
    }

    void OnDisable()
    {
        Brick.OnBrickDestroyed -= LadrilloDestruido; // Unsubscribe from the OnBrickDestroyed event to prevent memory leaks when the GameManager is disabled
    }
}
