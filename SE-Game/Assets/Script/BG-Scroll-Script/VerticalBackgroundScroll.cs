using UnityEngine;

public class VerticalBackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of the scroll (adjustable in the Inspector)

    private float spriteHeight; // Height of the background sprite
    private Vector3 startPosition; // Initial position of the background

    void Start()
    {
        // Get the height of the background sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteHeight = spriteRenderer.bounds.size.y;

        // Save the starting position of the background
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the background downward
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // Check if the background has moved completely off-screen
        if (transform.position.y < startPosition.y - spriteHeight)
        {
            // Reset the background to its starting position
            transform.position = startPosition;
        }
    }
}