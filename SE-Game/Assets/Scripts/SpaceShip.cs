using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float BulletSpeed = 8.0f;
    public float FireRate = 0.5f;

    private Camera gameCamera;
    private Rigidbody2D rigidBody;
    private bool IsAlive = true;
    
    public Transform BulletSpawn;
    public Rigidbody2D bulletPrefab;

    void Start()
    {
        gameCamera = Camera.main;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAlive)
        { 
            // Lấy input từ bàn phím
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            // Di chuyển phi thuyền
            transform.Translate(new Vector3(moveX, moveY, 0) * MoveSpeed * Time.deltaTime);

            if (FireRate < 0.5)
            {
                FireRate += Time.deltaTime;
            }
        }

        ClampPosition();
        HandleShooting();
    }

    void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space) && FireRate >= 0.5f)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, BulletSpawn.position, Quaternion.identity);
            FireRate = 0;

            bullet.AddForce(BulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroids"))
        {
            IsAlive = false;
            Destroy(gameObject);
        }
    }

    void ClampPosition()
    {
        // Lấy vị trí phi thuyền
        Vector3 pos = transform.position;

        // Tính toán biên của Camera (trái dưới và phải trên)
        Vector3 bottomLeft = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, Mathf.Abs(gameCamera.transform.position.z - transform.position.z)));
        Vector3 topRight = gameCamera.ViewportToWorldPoint(new Vector3(1, 1, Mathf.Abs(gameCamera.transform.position.z - transform.position.z)));

        // Lấy kích thước của phi thuyền để bù trừ
        float shipWidth = GetComponent<SpriteRenderer>().bounds.size.x / 2;
        float shipHeight = GetComponent<SpriteRenderer>().bounds.size.y;

        // Giới hạn vị trí x và 
        pos.x = Mathf.Clamp(pos.x, bottomLeft.x + shipWidth, topRight.x - shipWidth);
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y - (float)0.5 * shipHeight, topRight.y - (float)1.5 * shipHeight);

        // Gán lại vị trí giới hạn
        transform.position = pos;
    }
}
