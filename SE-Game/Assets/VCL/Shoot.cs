using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab viên đạn
    public Transform bulletSpawnPoint; // Vị trí xuất phát của đạn
    public float fireRate = 0.2f; // Tốc độ bắn (thời gian giữa các viên đạn)

    private float nextFireTime = 0f;

    void Update()
    {
        // Nhấn phím Space để bắn đạn
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        // Tạo viên đạn từ Prefab
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
}
