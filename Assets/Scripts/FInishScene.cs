using UnityEngine;

namespace WatsonMovementControl
{
    public class SimpleKeyInteract : MonoBehaviour
    {
        public string requiredKeyName = "Door Key";
        public string successMessage = "You finished the tutorial!";

        public GameObject message;

        private bool isPlayerNear = false;
        private PlayerInventory playerInventory;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = true;
                playerInventory = other.GetComponent<PlayerInventory>();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = false;
                playerInventory = null;
            }
        }

        void Update()
        {
            if (isPlayerNear && playerInventory != null &&  VirtualInputManager.Instance.Interacts)
            {
                if (HasKey())
                {
                    message.SetActive(true);
                }
            }
        }

        bool HasKey()
        {
            foreach (var item in playerInventory.items)
            {
                if (item.itemName == requiredKeyName)
                    return true;
            }
            return false;
        }
    }
}
