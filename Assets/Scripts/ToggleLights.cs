using UnityEngine;
using UnityEngine.UI;

public class LightToggle : MonoBehaviour
{
    public Light lightSource;  // Reference to the Light component
    public Button toggleButton; // Reference to the UI Button

    void Start()
    {
        // Ensure the light source and button are assigned
        if (lightSource == null)
        {
            Debug.LogError("Light source is not assigned.");
        }

        if (toggleButton != null)
        {
            toggleButton.onClick.AddListener(ToggleLight);
        }
        else
        {
            Debug.LogError("Toggle button is not assigned.");
        }
    }

    void ToggleLight()
    {
        if (lightSource != null)
        {
            lightSource.enabled = !lightSource.enabled;
        }
    }
}
