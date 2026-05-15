using UnityEngine;

public class StartGamePanel : MonoBehaviour
{
    public GameObject startPanel;

    void Start()
    {
        startPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene("PetRoom_Level1");
    }

}
