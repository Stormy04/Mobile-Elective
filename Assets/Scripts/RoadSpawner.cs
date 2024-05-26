using UnityEngine;
using System.Collections.Generic;
public class RoadSpawner : MonoBehaviour
{
    public GameObject roadSegmentPrefab; // Road segment prefab
    public int numberOfSegments = 5; // Number of road segments to keep active
    public float roadLength = 30.0f; // Length of each road segment

    private Transform player;
    private Queue<GameObject> roadSegments = new Queue<GameObject>();
    private Vector3 nextSpawnPoint;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nextSpawnPoint = Vector3.zero;

        for (int i = 0; i < numberOfSegments; i++)
        {
            SpawnRoadSegment();
        }
    }

    void Update()
    {
        if (player.position.z > nextSpawnPoint.z - (numberOfSegments * roadLength))
        {
            SpawnRoadSegment();
            DespawnRoadSegment();
        }
    }

    void SpawnRoadSegment()
    {
        GameObject segment = Instantiate(roadSegmentPrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint.z += roadLength;
        roadSegments.Enqueue(segment);
    }

    void DespawnRoadSegment()
    {
        GameObject oldSegment = roadSegments.Dequeue();
        Destroy(oldSegment);
    }
}
