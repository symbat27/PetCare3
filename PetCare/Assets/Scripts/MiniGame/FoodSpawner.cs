using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;

    public float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFood), 1f, spawnRate);
    }

    void SpawnFood()
    {
        float randomX = Random.Range(-2.2f, 2.2f);

        Vector2 spawnPos = new Vector2(randomX, transform.position.y);

        Instantiate(foodPrefab, spawnPos, Quaternion.identity);
    }
}