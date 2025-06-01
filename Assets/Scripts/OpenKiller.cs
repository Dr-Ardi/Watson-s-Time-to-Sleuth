using UnityEngine;
using TMPro;

public class OpenKiller : MonoBehaviour
{
    public GameObject popupTextObject; // Assign the TextMeshPro object in the inspector
    public float displayTime = 2f;

    private TextMeshProUGUI popupText;

    void Start()
    {
        popupText = popupTextObject.GetComponent<TextMeshProUGUI>();
        popupTextObject.SetActive(false);
    }

    public void ShowMessage(string message)
    {
        popupText.text = message;
        popupTextObject.SetActive(true);
        CancelInvoke(nameof(HidePopup));
        Invoke(nameof(HidePopup), displayTime);
    }

    void HidePopup()
    {
        popupTextObject.SetActive(false);
    }
}
