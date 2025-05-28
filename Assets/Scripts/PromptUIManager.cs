using UnityEngine;
using TMPro; // If using TextMeshPro
using System.Collections;

public class PromptUIManager : MonoBehaviour
{
    public static PromptUIManager Instance;

    public TextMeshProUGUI promptText; // Assign in inspector

    private void Awake()
    {
        Instance = this;
    }

    private Coroutine clearRoutine;

    public void SetPrompt(string message, float clearAfterSeconds = -1f)
    {
        promptText.text = message;

        if (clearRoutine != null)
            StopCoroutine(clearRoutine);

        if (clearAfterSeconds > 0f)
            clearRoutine = StartCoroutine(ClearAfterDelay(clearAfterSeconds));
    }

    private IEnumerator ClearAfterDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ClearPrompt();
    }

    public void ClearPrompt()
    {
        promptText.text = "";
    }
}
