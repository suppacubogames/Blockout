using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of the paddle movement
    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component for physics interactions
    [SerializeField] private Vector2 inputs; // Vector to store input values for movement

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to the paddle
    }

    // Update is called once per frame
    void Update()
    {
        //PaddleMovement(); // Call the method to handle paddle movement
        //Physics2D(); // Call the method to handle physics-related updates for the paddle
    }

    void FixedUpdate()
    {
        Physics2D(); // Call the method to handle physics-related updates for the paddle
    }

    void PaddleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime; // Calculate movement vector
        transform.Translate(movement); // Move the paddle based on the calculated movement vector
    }

    void Physics2D()
    {
        inputs.x = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        inputs.y = Input.GetAxisRaw("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)

        rb.linearVelocity = inputs * speed; // Set the velocity of the paddle based on input and speed
    }
}
