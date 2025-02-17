using UnityEngine;

public class VerticalBackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed of the scroll
    private float spriteHeight; // Height of a single background sprite
    private Transform[] backgrounds; // Array to hold background parts

    void Start()
    {
        // Get all child sprites (assumes the script is attached to a parent GameObject)
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // Get the height of a single background sprite
        spriteHeight = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        // Move each background downward
        foreach (Transform bg in backgrounds)
        {
            bg.position += Vector3.down * scrollSpeed * Time.deltaTime;
        }

        // Check if any background has moved completely off-screen
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.y <= -spriteHeight * 1.5f) // Wait until fully out of view
            {
                // Find the highest background piece
                Transform highest = backgrounds[0];
                foreach (Transform other in backgrounds)
                {
                    if (other.position.y > highest.position.y)
                        highest = other;
                }

                // Move the current background above the highest one
                bg.position = highest.position + Vector3.up * spriteHeight;
            }
        }
    }
}
