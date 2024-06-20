using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [Header("UI Slider")]
    public Slider masterVolumeSlider;

    [Header("Audio Sources")]
    public AudioSource[] audioSources;

    private void Start()
    {
        // Load saved master volume or set to default (1.0f)
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);

        // Set slider and audio sources to saved value
        masterVolumeSlider.value = masterVolume;
        SetMasterVolume(masterVolume);

        // Add listener for slider value changes
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    public void SetMasterVolume(float volume)
    {
        foreach (var audioSource in audioSources)
        {
            audioSource.volume = volume;
        }
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
}
