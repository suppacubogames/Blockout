using UnityEngine;

public class Brick : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false); // Deactivate the brick when it collides with another object (e.g., the ball)
    }
}
