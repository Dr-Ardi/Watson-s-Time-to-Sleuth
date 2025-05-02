using UnityEngine;

namespace WatsonMovementControl
{
    public class Watson : MonoBehaviour
    {
        void Update()
        {
            if (VirtualInputManager.Instance.MoveRight) {   this.gameObject.transform.Translate(Vector3.right * 10f * Time.deltaTime);  }
            if (VirtualInputManager.Instance.MoveLeft) {   this.gameObject.transform.Translate(Vector3.left * 10f * Time.deltaTime);  }
            if (VirtualInputManager.Instance.MoveForward) {   this.gameObject.transform.Translate(Vector3.forward * 10f * Time.deltaTime);  }
            if (VirtualInputManager.Instance.MoveBackward) {   this.gameObject.transform.Translate(-Vector3.forward * 10f * Time.deltaTime);  }
        }
    }
}

