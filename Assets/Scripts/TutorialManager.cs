using UnityEngine;
using TMPro;
using WatsonMovementControl;

public class TutorialManager : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public GameObject popupPanel;

    public int step = 0;

    private bool calledE = false;
    private bool calledEx = false;
    private bool calledF = false;
    public bool calledt = false;

    public bool skipped = false;

    void Start()
    {
        ShowMessage("Use W A S D to walk and hold Shift to Run", 3f);
    }

    void Update()
    {
        bool moved = (VirtualInputManager.Instance.MoveRight || VirtualInputManager.Instance.MoveLeft || VirtualInputManager.Instance.MoveBackward || VirtualInputManager.Instance.MoveForward);
        if (step == 0 && moved && !skipped)
        {
            CancelInvoke(nameof(HideMessage));
            Invoke(nameof(HideMessage), 1);
        }
        if (step == 1 && !calledE && !skipped)
        {
            ShowMessage("There's a Note on the table", 0f);
            calledE = true;
        }
        if (step == 1 && calledE && VirtualInputManager.Instance.Interacts && !skipped)
        {
            Invoke(nameof(HideMessage), 0);
        }
        if (step == 3 && !calledEx && !skipped) 
        {
            ShowMessage("Additional buttons, I for Inventory, and Tab for Settings", 5f);
            calledEx = true;
        }
        if (step == 4 && !calledF && !skipped)
        {
            ShowMessage("Now, get the key to the front door and leave the house.", 3f);
            calledF = true;
        }
    }

    public void ShowMessage(string message, float duration = 0f)
    {
        popupPanel.SetActive(true);
        tutorialText.text = message;

        if (duration > 0)
        {
            Invoke(nameof(HideMessage), duration);
        }

        // ShowMessage("There's a Note on the table", 5f);
    }

    public void HideMessage()
    {
        popupPanel.SetActive(false);
        step += 1;
    }

    public void SKip()
    {
        skipped = true;
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 0);
    }
}
