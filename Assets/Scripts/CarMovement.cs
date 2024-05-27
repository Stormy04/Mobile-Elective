using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float despawnTime = 3.0f; 

    private Transform player;
    private bool isBehindPlayer = false;
    private float timeBehindPlayer = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
