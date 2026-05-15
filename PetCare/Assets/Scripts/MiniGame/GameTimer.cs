using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timeLeft = 60f;

    void Update()
    {
        timeLeft -= Time.deltaTime;

        int seconds = Mathf.CeilToInt(timeLeft);

        timerText.text = "Time: " + seconds;

        if (seconds <= 10)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = new Color(0.35f, 0.18f, 0.08f);
        }

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
