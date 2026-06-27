using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BrickSpawner brickSpawner; // Reference to the BrickSpawner script to access the list of bricks
    [SerializeField] private List<GameObject> bricks; // Total number of bricks in the game
    [SerializeField] private GameState currentGameState; // Current state of the game (Playing, Win, Lose)
    [SerializeField] private Transform ballHandler; // Reference to the BallHandler script to access the ball's position.
    [SerializeField] private Transform ball; // Reference to the Ball gameObject.
    [SerializeField] private float cooldown = 3; // Cooldown time in seconds before the player can continue playing after losing a life.
    [SerializeField] private TMP_Text scoreText, livesText, gameOverText, youWinText;

    private int score = 0;
    private int lives = 3;

    public enum GameState { Playing, Win, Lose, Respawning }

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
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();


    }

    void OnEnable()
    {
        Brick.OnBrickDestroyed += LadrilloDestruido; // Subscribe to the OnBrickDestroyed event to call the LadrilloDestruido method when a brick is destroyed
        Floor.OnFloorHit += OnBallTouchingFloor; // Subscribe to the OnFloorHit event to call the GameOver method when the ball hits the floor
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LadrilloDestruido()
    {
        score++; // Increment the score when a brick is destroyed
        scoreText.text = "Score: " + score.ToString();

        bool anyBrickAlive = bricks.Any(brick => brick.activeSelf); // Check if any brick in the list is still active (not destroyed)

        if (!anyBrickAlive)
        {
            currentGameState = GameState.Win;
            ball.gameObject.SetActive(false); // Deactivate the ball game object to prevent it from being used after the player has won the game
            youWinText.gameObject.SetActive(true);
        }
    }

    private void OnBallTouchingFloor()
    {
        currentGameState = GameState.Lose; // Set the game state to Lose when the player loses the game

        lives--;
        livesText.text = "Lives: " + lives.ToString();

        if (lives <= 0)
        {
            ball.gameObject.SetActive(false); // Deactivate the ball game object to prevent it from being used after the player has lost all lives
            currentGameState = GameState.Lose;
            gameOverText.gameObject.SetActive(true);
            Debug.Log("PERDISTE!"); // Log a message to the console indicating that the player has lost the game
        }
        else
        {
            ball.gameObject.SetActive(false); // Deactivate the ball game object to prevent it from being used while waiting for the cooldown time before respawning
            currentGameState = GameState.Respawning; // Set the game state to Respawning to indicate that the player has lost a life and is waiting to respawn the ball
            StartCoroutine(RespawnBall()); // Start the RespawnBall coroutine to wait for the cooldown time before respawning the ball

        }

    }

    public GameState GetCurrentGameState()
    {
        return currentGameState; // Return the current state of the game (Playing, Win, Lose)
    }

    void OnDisable()
    {
        Brick.OnBrickDestroyed -= LadrilloDestruido; // Unsubscribe from the OnBrickDestroyed event to prevent memory leaks when the GameManager is disabled
        Floor.OnFloorHit -= OnBallTouchingFloor; // Unsubscribe from the OnFloorHit event to prevent memory leaks when the GameManager is disabled
    }

    IEnumerator RespawnBall()
    {
        yield return new WaitForSeconds(cooldown); // Wait for the cooldown time before respawning the ball
        ball.position = ballHandler.position; // Reset the ball's position to the BallHandler's position
        ball.gameObject.SetActive(true); // Activate the ball game object to allow it to be used again
        currentGameState = GameState.Playing; // Set the game state back to Playing so the player can continue playing
    }
}
