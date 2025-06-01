using UnityEngine;

namespace WatsonMovementControl
{
    public class VirtualInputManager : MonoBehaviour
    {
        public static VirtualInputManager Instance = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this.gameObject);
            }
        }

        public bool MoveRight;
        public bool MoveLeft;
        public bool MoveForward;
        public bool MoveBackward;
        public bool Interacts;
        public bool Run;
        public bool Frozen; 
    }
}

