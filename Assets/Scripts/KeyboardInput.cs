using UnityEngine;
using UnityEngine.InputSystem;

namespace WatsonMovementControl 
{
    public class KeyboardInput: MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveRight = !VirtualInputManager.Instance.Frozen && Keyboard.current.dKey.isPressed;
            VirtualInputManager.Instance.MoveLeft = !VirtualInputManager.Instance.Frozen && Keyboard.current.aKey.isPressed;
            VirtualInputManager.Instance.MoveBackward = !VirtualInputManager.Instance.Frozen && Keyboard.current.wKey.isPressed;
            VirtualInputManager.Instance.MoveForward = !VirtualInputManager.Instance.Frozen && Keyboard.current.sKey.isPressed;
            VirtualInputManager.Instance.Interacts = !VirtualInputManager.Instance.Frozen && Keyboard.current.eKey.isPressed;
            VirtualInputManager.Instance.Run = !VirtualInputManager.Instance.Frozen && Keyboard.current.shiftKey.isPressed;
            VirtualInputManager.Instance.CheckInventory = !VirtualInputManager.Instance.Frozen && Keyboard.current.iKey.isPressed;
        }
    }
}
