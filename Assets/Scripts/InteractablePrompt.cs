using UnityEngine;

public class InteractablePrompt : MonoBehaviour
{
    public string promptMessage = "Press E";
    public string acquiredMessage = "Acquired Bedroom Key";
    private bool isPlayerNearby = false;
    private bool isAcquired = false;

    void Update()
    {
        if (isPlayerNearby && !isAcquired && Input.GetKeyDown(KeyCode.E))
        {
            AcquireItem();
        }
    }

    private void AcquireItem()
    {
        isAcquired = true;
        PromptUIManager.Instance.SetPrompt(acquiredMessage, 2f); // clear after 2 seconds


        // Optional: Destroy object, disable collider, play sound, etc.
        // Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAcquired)
        {
            isPlayerNearby = true;
            PromptUIManager.Instance.SetPrompt(promptMessage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            if (!isAcquired)
                PromptUIManager.Instance.ClearPrompt();
        }
    }
}
