using UnityEngine;

public class StarManager : MonoBehaviour
{
    public GameObject starPrefab; // Prefab ngôi sao
    public float spawnInterval; // Thời gian giữa các lần tạo
    public float spawnRangeX; // Phạm vi tạo ngôi sao theo trục X

    void Start()
    {
        // Bắt đầu gọi hàm spawn định kỳ
        InvokeRepeating("SpawnStar", 0f, spawnInterval);
    }

    void SpawnStar()
    {
        // Tính toán vị trí ngẫu nhiên theo trục X
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, Camera.main.orthographicSize + 1, 0);

        // Tạo ngôi sao mới
        Instantiate(starPrefab, spawnPosition, Quaternion.identity);
    }
}
