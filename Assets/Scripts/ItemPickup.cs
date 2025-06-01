using UnityEngine;
// using WatsonInventorySystem; // ✅ Only if you defined PlayerInventory in another namespace

namespace WatsonMovementControl
{
    public class KeyPickup : MonoBehaviour
    {
        public GameObject sherKeyObject; // Assign in Inspector
        private bool isPlayerNear = false;

        public static bool hasSherKey = false;
        public ItemData itemData;

        private GameObject player;

        void Update()
        {
            if (isPlayerNear && VirtualInputManager.Instance.Interacts)
            {
                hasSherKey = true;
                sherKeyObject.SetActive(false);

                if (player != null)
                {
                    PlayerInventory inventory = player.GetComponent<PlayerInventory>();
                    if (inventory != null)
                    {
                        inventory.AddItem(itemData);
                        Destroy(gameObject); // Optional: remove the key after pickup
                        Debug.Log("Picked up!");
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = true;
                player = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = false;
                player = null;
            }
        }
    }
}
