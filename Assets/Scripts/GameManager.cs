using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        Debug.Log("Brick destroyed!"); // Log a message to the console when the brick is deactivated (destroyed)

    }

    void OnDisable()
    {
        Brick.OnBrickDestroyed -= LadrilloDestruido; // Unsubscribe from the OnBrickDestroyed event to prevent memory leaks when the GameManager is disabled
    }
}
