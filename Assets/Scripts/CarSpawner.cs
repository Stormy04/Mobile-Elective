using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; // Array of car prefabs to spawn
    public Transform[] spawnPoints; // Array of points where cars can spawn
    public float spawnInterval = 1.5f; // Time between spawns

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnCar();
            timer = 0;
        }
    }

    void SpawnCar()
    {
        int carIndex = Random.Range(0, carPrefabs.Length);
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(carPrefabs[carIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
