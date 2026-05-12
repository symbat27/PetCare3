using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI ratingText;

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

        if (finalScore >= 15)
        {
            resultText.text = "YOU WIN!";
            ratingText.text = "Rating: 3 stars";
        }
        else if (finalScore >= 8)
        {
            resultText.text = "GOOD!";
            ratingText.text = "Rating: 2 stars";
        }
        else
        {
            resultText.text = "YOU LOSE!";
            ratingText.text = "Rating: 1 star";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Garden_Level2");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
