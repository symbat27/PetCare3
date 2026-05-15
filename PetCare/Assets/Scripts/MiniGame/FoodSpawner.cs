using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;

    public float spawnRate = 1f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFood), 1f, spawnRate);
    }

    void SpawnFood()
    {
        float randomX = Random.Range(-2.2f, 2.2f);

        Vector2 spawnPos = new Vector2(randomX, transform.position.y);

        int randomFood = Random.Range(0, foodPrefabs.Length);

        Instantiate(foodPrefabs[randomFood], spawnPos, Quaternion.identity);
    }
}