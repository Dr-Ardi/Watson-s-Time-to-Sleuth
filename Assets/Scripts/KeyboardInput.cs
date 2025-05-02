using UnityEngine;
using UnityEngine.InputSystem;

namespace WatsonMovementControl 
{
    public class KeyboardInput: MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveRight = Keyboard.current.dKey.isPressed;
            VirtualInputManager.Instance.MoveLeft = Keyboard.current.aKey.isPressed;
            VirtualInputManager.Instance.MoveBackward = Keyboard.current.wKey.isPressed;
            VirtualInputManager.Instance.MoveForward = Keyboard.current.sKey.isPressed;
            
        }
    }
}
