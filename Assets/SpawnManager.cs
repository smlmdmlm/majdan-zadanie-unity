using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefabToSpawn; // Reference to the prefab to spawn
    public Transform plate; // Reference to the plate area where prefabs and enemies will spawn
    public int numberOfPrefabs = 5; // Number of prefabs to spawn
    public Vector3 spawnAreaSize = new Vector3(5f, 0f, 5f); // Size of the spawn area
    public float prefabSpawnInterval = 1f; // Interval between spawning prefabs
    public float enemySpawnInterval = 3f; // Interval between spawning enemies

    void Start()
    {
        InvokeRepeating("SpawnPrefabs", 0f, prefabSpawnInterval);
    }

    void SpawnPrefabs()
    {
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            // Calculate a random position within the spawn area
            Vector3 spawnPosition = plate.position + new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                                                                 0f,
                                                                 Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f));
            // Spawn the prefab at the random position
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

  }
