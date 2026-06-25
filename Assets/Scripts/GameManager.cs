using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BrickSpawner brickSpawner; // Reference to the BrickSpawner script to access the list of bricks
    [SerializeField] private List<GameObject> bricks; // Total number of bricks in the game
    [SerializeField] private GameState currentGameState; // Current state of the game (Playing, Win, Lose)
    public enum GameState { Playing, Win, Lose }

    //singleton pattern
    public static GameManager Instance { get; private set; } // Singleton instance of the GameManager class

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance to this GameManager if it hasn't been set yet
        }
        else
        {
            Destroy(gameObject); // Destroy this GameManager if another instance already exists
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentGameState = GameState.Playing; // Set the initial game state to Playing
        bricks = brickSpawner.GetBricks(); // Get the list of bricks from the BrickSpawner script
    }

    void OnEnable()
    {
        Brick.OnBrickDestroyed += LadrilloDestruido; // Subscribe to the OnBrickDestroyed event to call the LadrilloDestruido method when a brick is destroyed
        Floor.OnFloorHit += GameOver; // Subscribe to the OnFloorHit event to call the GameOver method when the ball hits the floor
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
            currentGameState = GameState.Win;
            Debug.Log("All bricks destroyed! GREAT SAFE! YOU WIN! INTERNATIONAL SUPER STAR SOCCER DELUXE"); // Log a message to the console when all bricks are deactivated (destroyed). The message is a humorous reference to the game "International Superstar Soccer Deluxe" and is meant to celebrate the player's victory in the game.
        }
    }

    private void GameOver()
    {
        currentGameState = GameState.Lose; // Set the game state to Lose when the player loses the game
        Debug.Log("PERDISTE!"); // Log a message to the console indicating that the player has lost the game
    }

    public GameState GetCurrentGameState()
    {
        return currentGameState; // Return the current state of the game (Playing, Win, Lose)
    }

    void OnDisable()
    {
        Brick.OnBrickDestroyed -= LadrilloDestruido; // Unsubscribe from the OnBrickDestroyed event to prevent memory leaks when the GameManager is disabled
        Floor.OnFloorHit -= GameOver; // Unsubscribe from the OnFloorHit event to prevent memory leaks when the GameManager is disabled
    }
}
