using UnityEngine;

public class RoadMover : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Move the road backward to create the illusion of the car moving forward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Reposition the road if it goes too far
        if (transform.position.z < -10f)
        {
            transform.position += new Vector3(0, 0, 20f);
        }
    }
}
