using UnityEngine;
using System;

public class Brick : MonoBehaviour
{
    public static event Action OnBrickDestroyed; // Event to notify when a brick is destroyed

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false); // Deactivate the brick when it collides with another object (e.g., the ball)
    }

    void OnDisable()
    {
        OnBrickDestroyed?.Invoke();
    }
}
