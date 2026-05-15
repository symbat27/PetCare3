using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void EndGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ResultScene");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Garden_Level2");
    }
}
