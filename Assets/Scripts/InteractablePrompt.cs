using UnityEngine;
using UnityEngine.InputSystem;

public class InteractablePrompt : MonoBehaviour
{
    public string promptMessage = "Press E";
    public string acquiredMessage = "Acquired Bedroom Key";
    public string requiredItemName = "Bedroom Key"; 

    private bool isPlayerNearby = false;
    private bool isAcquired = false;

    private PlayerInventory playerInventory;

    void Update()
    {
        if (isPlayerNearby && !isAcquired && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (IsItemRequirementMet())
            {
                AcquireItem();
            }
        }

    }

    private void AcquireItem()
    {
        isAcquired = true;
        PromptUIManager.Instance.SetPrompt(acquiredMessage, 2f); 
    }

    private bool IsItemRequirementMet()
    {
        if (string.IsNullOrWhiteSpace(requiredItemName))
            return true;

        if (playerInventory == null)
            return false;

        foreach (var item in playerInventory.items)
        {
            if (item != null && item.itemName == requiredItemName)
                return true;
        }

        return false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isAcquired)
        {
            isPlayerNearby = true;
            playerInventory = other.GetComponent<PlayerInventory>();
            if (string.IsNullOrWhiteSpace(requiredItemName))
            {
                PromptUIManager.Instance.SetPrompt(promptMessage);
            }
            foreach (var item in playerInventory.items)
            {
                if (item != null && item.itemName == requiredItemName)
                    PromptUIManager.Instance.SetPrompt(promptMessage);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            PromptUIManager.Instance.ClearPrompt();
        }
    }
}
