using UnityEngine;
using UnityEngine.SceneManagement;

public class CaseMenu : MonoBehaviour
{
    public void selectCase() {
        SceneManager.LoadScene("SampleScene");
    }
}
