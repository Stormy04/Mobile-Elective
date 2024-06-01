using UnityEngine;
public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs; // Array of car prefabs to spawn
    public Transform[] spawnPoints; // Array of points where cars can spawn for each lane
    public float spawnInterval = 1.5f; // Time between spawns
    public float carSpeed = 10.0f; // Speed of the spawned cars
    public float spawnDistance = 20.0f; // Distance in front of the player to spawn cars

    private Transform player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Calculate the spawn position based on player's position and velocity
        Vector3 spawnPosition = player.position + player.forward * spawnDistance + player.forward * player.GetComponent<Rigidbody>().velocity.magnitude * spawnInterval;

        // Check if it's time to spawn a new car
        if (timer >= spawnInterval)
        {
            SpawnCar(spawnPosition);
            timer = 0;
        }
    }

    void SpawnCar(Vector3 spawnPosition)
    {
        // Randomly select a lane
        int laneIndex = Random.Range(0, spawnPoints.Length);

        // Select a random spawn point from the chosen lane's spawn points
        Transform spawnPoint = spawnPoints[laneIndex];

        // Instantiate the car at the calculated spawn position on the chosen lane
        GameObject car = Instantiate(carPrefabs[Random.Range(0, carPrefabs.Length)], spawnPoint.position, spawnPoint.rotation);

        // Set the car speed
        CarMovement carMovement = car.GetComponent<CarMovement>();
        carMovement.speed = carSpeed;
    }
}