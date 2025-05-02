using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AspectRatio : MonoBehaviour
{
    public Button toggleButton;
    public TextMeshProUGUI buttonText;

    private bool isWidescreen = true;

    void Start()
    {
        toggleButton.onClick.AddListener(ToggleAspectRatio);
        UpdateButtonText();
    }

    void ToggleAspectRatio()
    {
        if (isWidescreen)
        {
            Screen.SetResolution(1440, 1080, FullScreenMode.Windowed);
        }
        else
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
        }

        isWidescreen = !isWidescreen;
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (isWidescreen)
            buttonText.text = "16:9";
        else
            buttonText.text = "4:3";
    }

}
