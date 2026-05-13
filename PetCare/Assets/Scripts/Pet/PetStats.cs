using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetStats : MonoBehaviour
{
    public Slider hungerSlider;
    public Slider happinessSlider;
    public Slider cleanlinessSlider;

    public TMP_Text hungerText;
    public TMP_Text happinessText;
    public TMP_Text cleanlinessText;
    public TMP_Text scoreText;

    private float hunger = 70f;
    private float happiness = 70f;
    private float cleanliness = 70f;

    private int score = 0;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        hunger -= Time.deltaTime * 1f;
        happiness -= Time.deltaTime * 0.7f;
        cleanliness -= Time.deltaTime * 0.5f;

        hunger = Mathf.Clamp(hunger, 0, 100);
        happiness = Mathf.Clamp(happiness, 0, 100);
        cleanliness = Mathf.Clamp(cleanliness, 0, 100);

        UpdateUI();
    }

    public void FeedPet()
    {
        hunger = Mathf.Clamp(hunger + 20, 0, 100);
        score += 10;
        UpdateUI();
    }

    public void CleanPet()
    {
        cleanliness = Mathf.Clamp(cleanliness + 20, 0, 100);
        score += 10;
        UpdateUI();
    }

    public void PlayWithPet()
    {
        happiness = Mathf.Clamp(happiness + 20, 0, 100);
        hunger = Mathf.Clamp(hunger - 5, 0, 100);
        score += 15;
        UpdateUI();
    }

    private void UpdateUI()
    {
        hungerSlider.value = hunger;
        happinessSlider.value = happiness;
        cleanlinessSlider.value = cleanliness;

        hungerText.text = "Hunger: " + Mathf.RoundToInt(hunger);
        happinessText.text = "Happiness: " + Mathf.RoundToInt(happiness);
        cleanlinessText.text = "Cleanliness: " + Mathf.RoundToInt(cleanliness);

        scoreText.text = "Score: " + score;
    }
}