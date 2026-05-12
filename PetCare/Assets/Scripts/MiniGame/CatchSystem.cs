using UnityEngine;
using TMPro;

public class CatchSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("FinalScore", score);
        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            score++;
            PlayerPrefs.SetInt("FinalScore", score);

            scoreText.text = "Score: " + score;

            Destroy(collision.gameObject);
        }
    }
}
