using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private float speed; // Speed of the paddle movement
    [SerializeField] private Vector2 inputs; // Vector to store input values for movement

    [SerializeField] private float minX, maxX; // Minimum and maximum X positions the paddle can move to

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PaddleMovement(); // Call the method to handle paddle movement
        ClampPaddlePosition(); // Call the method to clamp the paddle's position
    }

    void PaddleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        Vector3 movement = new Vector3(horizontal, 0f, 0f) * speed * Time.deltaTime; // Calculate movement vector
        transform.Translate(movement); // Move the paddle based on the calculated movement vector
    }

    void ClampPaddlePosition()
    {
        float clampedHorizontal = Mathf.Clamp(transform.position.x, minX, maxX); // Clamp the horizontal input to ensure the paddle stays within bounds
        transform.position = new Vector3(clampedHorizontal, transform.position.y, transform.position.z); // Apply the clamped position to the paddle
    }

    //  methods PaddleMovement and ClampPaddlePosition don't get in the way of each other, they work together
    //  to ensure the paddle moves smoothly while staying within the defined boundaries.
    //  The way this works is that PaddleMovement handles the actual movement of the paddle based on player input,
    //  while ClampPaddlePosition ensures that after the movement is applied, the paddle's position is adjusted if it
    //  goes beyond the defined minimum and maximum X values. This separation of concerns allows for cleaner code and 
    //  makes it easier to manage the paddle's behavior.
}
