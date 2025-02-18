using UnityEngine;
using UnityEngine.SceneManagement;

public class StarController : MonoBehaviour
{
    public float speed;
    public int point = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu va chạm với SpaceShip
        if (collision.CompareTag("Player"))
        {
            // Tính điểm
            ScoreManager.instance.AddScore(point);

            // Hủy ngôi sao
            Destroy(gameObject);
        }
    }


    void Update()
    {
        // Di chuyển ngôi sao theo trục Y (từ trên xuống)
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Kiểm tra nếu ngôi sao ra khỏi màn hình thì hủy
        if (transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject);
        }
    }
}
