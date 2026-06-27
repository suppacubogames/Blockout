using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component for physics interactions

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the ball
        SetVelocity(); // Set the initial velocity of the ball to start moving
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVelocity()
    {
        rb.linearVelocity = new Vector2(5f, -5f); // Set the initial velocity of the ball to move diagonally downwards to the right

    }

    void OnEnable()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the ball

        }
        rb.linearVelocity = new Vector2(5f, -5f); // Set the initial velocity of the ball to move diagonally downwards to the right

    }

}
