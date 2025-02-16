using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float moveSpeed;
    private Camera gameCamera;

    void Start()
    {
        gameCamera = Camera.main;
    }

    void Update()
    {
        // Lấy input từ bàn phím
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Di chuyển phi thuyền
        transform.Translate(new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);

        ClampPosition();
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
        pos.y = Mathf.Clamp(pos.y, bottomLeft.y - (float) 0.5 * shipHeight, topRight.y - (float)1.5 * shipHeight);

        // Gán lại vị trí giới hạn
        transform.position = pos;
    }
}
