using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]
    private Asteroid asteroidPrefab;
    public int NumberOfAsteroid = 0;
    public int level = 0;
    public float Cooldown = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (NumberOfAsteroid == 0)
        //{
        //    level++;

        //    int amount = 50 + (level * 2);

        //    for (int i = 0; i < amount; i++)
        //    {
        //        while (Cooldown > 0)
        //        {
        //            Cooldown -= Time.deltaTime;
        //        }
        //        SpawnAsteroid();
        //        Cooldown = 0.5f;
        //    }
        //}

        if (Cooldown <= 0)
        {
            Cooldown = Random.Range(0.2f, 1f);

            level++;

            int amount = Random.Range(1,5) + (level/100 * 2);

            for (int i = 0; i < amount; i++)
            {
                SpawnAsteroid();
            }
        }

        Cooldown -= Time.deltaTime;
    }

    private void SpawnAsteroid()
    {
        // How far along the edge.
        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

        // Which edge.
        int edge = Random.Range(0, 2);
        if (edge == 0)
        {
            viewportSpawnPosition = new Vector2(offset, 1.5f);
        }
        else if (edge == 1)
        {
            viewportSpawnPosition = new Vector2(-offset, 1.5f);
        }
        /*else if (edge == 2)
        {
            viewportSpawnPosition = new Vector2(0, offset);
        }
        else if (edge == 3)
        {
            viewportSpawnPosition = new Vector2(1, offset);
        }*/

        // Create the asteroid.
        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);

        asteroidPrefab.Size = Random.Range(0.5f, 1.5f);

        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.manager = this;
    }
}
