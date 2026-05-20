using UnityEngine;
using TMPro;

public class CatchSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public AudioClip catchSound;
    public AudioClip virusSound;

    private AudioSource audioSource;

    private int score = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        score = 0;

        PlayerPrefs.SetInt("FinalScore", score);

        scoreText.text = "Score: " + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            score++;

            audioSource.PlayOneShot(catchSound);

            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Virus"))
        {
            score--;

            if (score < 0)
            {
                score = 0;
            }

            audioSource.PlayOneShot(virusSound, 2f);

            Destroy(collision.gameObject);
        }

        PlayerPrefs.SetInt("FinalScore", score);
        PlayerPrefs.SetInt("FoodPoints", score);

        scoreText.text = "Score: " + score;
    }
}
