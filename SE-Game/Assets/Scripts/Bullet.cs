using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletLifetime = 1.5f;


    private void Awake()
    {
        Destroy(gameObject, BulletLifetime);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
