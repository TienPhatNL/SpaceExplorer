using UnityEngine;

public class BulletSpawnControl : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Transform spaceShip;

    void Update()
    {
        // Đảm bảo BulletSpawnPoint luôn ở trên SpaceShip
        bulletSpawnPoint.position = spaceShip.position + new Vector3(0, 1, 0); // Thay đổi (0, 1, 0) theo ý bạn
    }
}
