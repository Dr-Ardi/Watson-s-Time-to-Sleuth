using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public void LoadPreviousScene(string previousSceneName = null)
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int previousIndex = currentIndex - 1;

        if (!string.IsNullOrEmpty(previousSceneName))
        {
            SceneManager.LoadScene(previousSceneName);
        }
        else if (previousIndex >= 0)
        {
            SceneManager.LoadScene(previousIndex);
        }
        else
        {
            Debug.LogWarning("No previous scene available!");
        }
    }
}
