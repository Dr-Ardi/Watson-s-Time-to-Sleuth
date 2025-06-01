using UnityEngine;
using UnityEngine.InputSystem;

namespace WatsonMovementControl 
{
    public class KeyboardInput: MonoBehaviour
    {
        void Update()
        {
            VirtualInputManager.Instance.MoveRight = Keyboard.current.dKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.MoveLeft = Keyboard.current.aKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.MoveBackward = Keyboard.current.wKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.MoveForward = Keyboard.current.sKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.Interacts = Keyboard.current.eKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.Run = Keyboard.current.shiftKey.isPressed && !VirtualInputManager.Instance.Frozen;
            VirtualInputManager.Instance.CheckInventory = Keyboard.current.iKey.isPressed && !VirtualInputManager.Instance.Frozen;
        }
    }
}
