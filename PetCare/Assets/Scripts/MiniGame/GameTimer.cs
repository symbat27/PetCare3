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

        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}
