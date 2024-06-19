using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float despawnTime = 3.0f;
    public int scoreReward = 10;

    private Transform player;
    private PlayerScore playerScore;
    private bool isBehindPlayer = false;
    private float timeBehindPlayer = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerScore = player.GetComponent<PlayerScore>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z < player.position.z)
        {
            if (!isBehindPlayer)
            {
                isBehindPlayer = true;
                timeBehindPlayer = 0.0f;

                // Reward the player with points when they pass the car
                if (playerScore != null)
                {
                    playerScore.AddPoints(scoreReward);
                }
            }

            timeBehindPlayer += Time.deltaTime;
            if (timeBehindPlayer >= despawnTime)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            isBehindPlayer = false;
            timeBehindPlayer = 0.0f;
        }
    }
}
