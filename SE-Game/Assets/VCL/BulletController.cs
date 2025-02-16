using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Tốc độ bay của đạn
    public float lifetime = 2f; // Thời gian tồn tại của đạn

    void Start()
    {
        // Hủy đạn sau một khoảng thời gian
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Di chuyển đạn theo hướng lên
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
