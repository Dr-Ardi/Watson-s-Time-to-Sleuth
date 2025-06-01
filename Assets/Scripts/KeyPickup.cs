using UnityEngine;

namespace WatsonMovementControl
{
    public class KeyPickup : MonoBehaviour
    {
        public GameObject sherKeyObject; // Assign in Inspector
        private bool isPlayerNear = false;

        // Simulating inventory
        public static bool hasSherKey = false;

        void Update()
        {
            if (isPlayerNear && VirtualInputManager.Instance.Interacts)
            {
                hasSherKey = true;
                sherKeyObject.SetActive(false);  // Hide the key in the world
                Debug.Log("Sher key picked up!");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNear = false;
            }
        }
    }
}
