using UnityEngine;

namespace WatsonMovementControl
{
    public class DoorController : MonoBehaviour
    {
        public string requiredKeyName = "Sherlock Key"; // Name of the key needed
        private bool isPlayerNear = false;
        private PlayerInventory playerInventory;

        void Update()
        {
            if (isPlayerNear && VirtualInputManager.Instance.Interacts)
            {
                if (playerInventory == null)
                {
                    Debug.LogWarning("PlayerInventory is null. Is the player tagged 'Player' and has a PlayerInventory component?");
                    return;
                }

                if (HasKey())
                {
                    Debug.Log("Door unlocked and removed.");
                    Destroy(gameObject); // 💥 Make the door disappear
                }
                else
                {
                    Debug.Log("You need the key to open this door.");
                }
            }
        }

        private bool HasKey()
        {
            foreach (var item in playerInventory.items)
            {
                if (item.itemName == requiredKeyName)
                    return true;
            }
            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = true;
                playerInventory = other.GetComponent<PlayerInventory>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = false;
                playerInventory = null;
            }
        }
    }
}
