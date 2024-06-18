using UnityEngine;

public class PoliceLightsController : MonoBehaviour
{
    public Light redLight;
    public Light blueLight;
    public float blinkInterval = 0.5f;

    private float timer;
    private bool isRedLightOn = true; // Track which light is currently on

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= blinkInterval)
        {
            if (isRedLightOn)
            {
                redLight.enabled = false;
                blueLight.enabled = true;
                isRedLightOn = false;
            }
            else
            {
                redLight.enabled = true;
                blueLight.enabled = false;
                isRedLightOn = true;
            }

            timer = 0f;
        }
    }
}
