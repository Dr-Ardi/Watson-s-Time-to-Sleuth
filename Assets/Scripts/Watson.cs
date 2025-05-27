using UnityEngine;

namespace WatsonMovementControl
{
    [RequireComponent(typeof(CharacterController))]
    public class Watson : MonoBehaviour
    {
        public float speed = 5f;
        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            Vector3 move = Vector3.zero;

            if (VirtualInputManager.Instance.MoveRight)
                move += Vector3.right;
            if (VirtualInputManager.Instance.MoveLeft)
                move += Vector3.left;
            if (VirtualInputManager.Instance.MoveForward)
                move += Vector3.forward;
            if (VirtualInputManager.Instance.MoveBackward)
                move += Vector3.back;

            controller.Move(move.normalized * speed );
        }
    }
}


