using UnityEngine;
using UnityEngine.SceneManagement;

namespace WatsonMovementControl
{
    public class GoToScene : MonoBehaviour
    {
        public string sceneToLoad;
        private bool playerInTrigger = false;

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInTrigger = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInTrigger = false;
            }
        }

        void Update()
        {
            if (playerInTrigger && VirtualInputManager.Instance.Interacts)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

}