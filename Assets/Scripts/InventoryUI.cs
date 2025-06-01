// InventoryUI.cs
using UnityEngine;
using UnityEngine.UI;

namespace WatsonMovementControl
{
    public class InventoryUI : MonoBehaviour
    {
        public PlayerInventory playerInventory;
        public Transform slotsParent;
        public GameObject itemSlotPrefab;

        void UpdateUI()
        {
            foreach (Transform child in slotsParent)
                Destroy(child.gameObject);

            foreach (var item in playerInventory.items)
            {
                GameObject slot = Instantiate(itemSlotPrefab, slotsParent);
                slot.GetComponent<Image>().sprite = item.icon;
            }
        }

        void Update()
        {
            if (VirtualInputManager.Instance.CheckInventory)
            {
                gameObject.SetActive(!gameObject.activeSelf);
                if (gameObject.activeSelf)
                    UpdateUI();
            }
        }
    }
}