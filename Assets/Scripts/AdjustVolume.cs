using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdjustVolume : MonoBehaviour
{
    public Slider volumeSlider;
    public TextMeshProUGUI volumeText;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;
        volumeText.text = "Volume: " + Mathf.RoundToInt(savedVolume * 100) + "%";

        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("volume", volume);
        volumeText.text = Mathf.RoundToInt(volume * 100) + "%";
    }
}
