using UnityEngine;

namespace WatsonMovementControl
{
    [RequireComponent(typeof(CharacterController))]
    public class Watson : MonoBehaviour
    {
        public float speed = 5f;
        private CharacterController controller;
        public Animator animator;

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
            if (VirtualInputManager.Instance.MoveBackward)
                move += Vector3.forward;
            if (VirtualInputManager.Instance.MoveForward)
                move += Vector3.back;

            if (move != Vector3.zero)
            {
                // Rotate instantly to direction
                transform.rotation = Quaternion.LookRotation(move.normalized);

                // Move forward
                controller.Move(transform.forward * speed * Time.deltaTime);

                // Set walking animation
                animator.SetBool("IsWalking", true);
            }
            else
            {
                // Not moving: idle animation
                animator.SetBool("IsWalking", false);
            }

        }
    }
}


