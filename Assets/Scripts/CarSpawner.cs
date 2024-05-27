using UnityEngine;
using System.Collections.Generic;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; 
    public Transform[] spawnPoints; 
    public float spawnInterval = 1.5f; 
    public float carSpeed = 10.0f;
    public float occupiedDuration = 3.0f;

    private float timer;
    private Dictionary<int, float> occupiedTimers = new Dictionary<int, float>(); 

    void Update()
    {
        timer += Time.deltaTime;

    
        List<int> keysToClear = new List<int>();
        foreach (var key in new List<int>(occupiedTimers.Keys))
        {
            occupiedTimers[key] -= Time.deltaTime;
            if (occupiedTimers[key] <= 0)
            {
                keysToClear.Add(key);
            }
        }

    
        foreach (var key in keysToClear)
        {
            occupiedTimers.Remove(key);
        }

     
        if (timer >= spawnInterval)
        {
            SpawnCar();
            timer = 0;
        }
    }

    void SpawnCar()
    {
        if (spawnPoints.Length == 0) return;

        int carIndex = Random.Range(0, carPrefabs.Length);
        int spawnPointIndex = GetRandomSpawnPointIndex();

        if (spawnPointIndex == -1) return; 

     
        Vector3 spawnPosition = spawnPoints[spawnPointIndex].position - transform.forward * 50.0f;

        GameObject car = Instantiate(carPrefabs[carIndex], spawnPosition, Quaternion.identity);

     
        CarMovement carMovement = car.GetComponent<CarMovement>();
        carMovement.speed = carSpeed;

        
        occupiedTimers[spawnPointIndex] = occupiedDuration;
    }

    int GetRandomSpawnPointIndex()
    {
        List<int> availableSpawnIndices = new List<int>();

        
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (!occupiedTimers.ContainsKey(i))
            {
                availableSpawnIndices.Add(i);
            }
        }

        
        if (availableSpawnIndices.Count > 0)
        {
            return availableSpawnIndices[Random.Range(0, availableSpawnIndices.Count)];
        }
        else
        {
            return -1; 
        }
    }
}
