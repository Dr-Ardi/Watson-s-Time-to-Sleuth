using UnityEngine;
using UnityEngine.InputSystem;

public class CameraTrigger : MonoBehaviour
{
    public string rightKeyCamera = "221b_bed_room_john";
    public string leftKeyCamera = "221b_living_room";
    private bool playerInside = false;
    private GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            player = null;
        }
    }

    void Update()
    {
        if (!playerInside || player == null)
            return;

        // Check for player input while inside trigger
        if (Keyboard.current.dKey.isPressed)
        {
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                CameraPositionManager.Instance.MoveCameraTo(rightKeyCamera, mainCam);
            }
        }
        else if (Keyboard.current.aKey.isPressed)
        {
            Camera mainCam = Camera.main;
            if (mainCam != null)
            {
                CameraPositionManager.Instance.MoveCameraTo(leftKeyCamera, mainCam);
            }
        }
    }
}
