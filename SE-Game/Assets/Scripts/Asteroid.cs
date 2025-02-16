using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float Size = 1f;
    public AsteroidManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Scale the Asteroid by saved size.
        transform.localScale = 1f * Size * Vector2.one;

        // Add Asteroid movements (bigger asteroids moves slower)
        Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.Range(-0.25f, 0.25f), -1).normalized;
        float spawnSpeed = Random.Range(3f-Size, 5f-Size);
        rigidBody.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);
        rigidBody.angularVelocity = 1.0f * Random.Range(-500.0f, 500.0f);
        // Creation
        manager.NumberOfAsteroid++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
       manager.NumberOfAsteroid--;
    }
}
