using UnityEngine;
using UnityEngine.InputSystem;

namespace WatsonMovementControl
{
    public class PopupController : MonoBehaviour
    {
        public GameObject popupPanel;
        public bool uiItem = false;

        private bool isPlayerNearby = false;


        public void Update()
        {
            if (uiItem)
            {
                if (Keyboard.current.tabKey.wasPressedThisFrame)
                {
                    popupPanel.SetActive(!popupPanel.activeSelf);
                    VirtualInputManager.Instance.Frozen = popupPanel.activeSelf;
                }
            }
            else
            {
                if (isPlayerNearby && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    ShowPopup();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNearby = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerNearby = false;
            }
        }

        public void ShowPopup()
        {
            popupPanel.SetActive(true);
            VirtualInputManager.Instance.Frozen = true;
        }

        public void HidePopup()
        {
            popupPanel.SetActive(false);
            VirtualInputManager.Instance.Frozen = false;
        }
    }
}