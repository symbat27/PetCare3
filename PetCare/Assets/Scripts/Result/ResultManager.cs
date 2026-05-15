using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    public Image dog1;
    public Image dog2;
    public Image dog3;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        finalScoreText.text = "Score: " + finalScore;
        highScoreText.text = "High Score: " + highScore;

        dog1.color = new Color(0.4f, 0.4f, 0.4f, 1f);
        dog2.color = new Color(0.4f, 0.4f, 0.4f, 1f);
        dog3.color = new Color(0.4f, 0.4f, 0.4f, 1f);

        if (finalScore <= 10)
        {
            resultText.text = "YOU LOSE!";
        }
        else if (finalScore <= 20)
        {
            resultText.text = "GOOD!";
            dog1.color = Color.white;
        }
        else if (finalScore <= 45)
        {
            resultText.text = "AWESOME!";
            dog1.color = Color.white;
            dog2.color = Color.white;
        }
        else
        {
            resultText.text = "PERFECT!";
            dog1.color = Color.white;
            dog2.color = Color.white;
            dog3.color = Color.white;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Garden_Level2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
