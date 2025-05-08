using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings : MonoBehaviour
{
    public void GoToSettingsScene() 
    {
        SceneManager.LoadScene("SettingsScene");
    }

}

