using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartTutorial() 
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void PlayGame() 
    {
        SceneManager.LoadScene("CasesScene");
    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }
}
