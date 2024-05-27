using UnityEngine;
using System.Collections.Generic;

public class RoadSpawner : MonoBehaviour
{
    public GameObject roadSegmentPrefab; 
    public int numberOfSegments = 5;
    public float roadLength = 30.0f; 
    public float despawnDistance = 50.0f; 

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
        if (player.position.z > nextSpawnPoint.z - (numberOfSegments * roadLength) + roadLength)
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
        if (roadSegments.Count > numberOfSegments)
        {
            GameObject oldSegment = roadSegments.Dequeue();
            Destroy(oldSegment);
        }
    }
}
